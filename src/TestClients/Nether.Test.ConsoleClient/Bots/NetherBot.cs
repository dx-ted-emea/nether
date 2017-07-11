﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Nether.Ingest;
using Nether.Ingest.MessageFormats;
using System;
using System.Threading.Tasks;

namespace Nether.Test.ConsoleClient
{
    public class NetherBot
    {
        private IAnalyticsClient _client;
        private IGamerTagProvider _gamerTagProvider;
        private IGameSessionProvider _gameSessionProvider;
        private NetherBotOptions _options;

        public string GamerTag { get; private set; }
        public string GameSession { get; private set; }
        public DateTime StartTime { get; private set; }
        public bool SessionEnded { get; private set; }

        private bool _started = false;
        private long _tickNo = 0;
        private DateTime _lastTick;
        private DateTime _lastHeartBeatMsgSent;

        public NetherBot(IAnalyticsClient client, IGamerTagProvider gamerTagProvider, IGameSessionProvider gameSessionProvider, NetherBotOptions options = null)
        {
            _client = client;
            _gamerTagProvider = gamerTagProvider;
            _gameSessionProvider = gameSessionProvider;
            _options = options ?? new NetherBotOptions();
        }

        private IAnalyticsClient GetClient(bool warmup)
        {
            // Delay use of real client until warmup period is over
            return warmup ? new NullAnalyticsClient() : _client;
        }

        private async Task StartAsync(DateTime now, bool warmup)
        {
            Console.Write("A");

            GamerTag = _gamerTagProvider.GetGamerTag();
            GameSession = _gameSessionProvider.GetGameSession();
            StartTime = now;
            var timeAlive = TimeSpan.Zero;

            await OnStartAsync(GetClient(warmup), now);

            _started = true;
        }

        public async Task<bool> TickAsync(DateTime now, bool warmup)
        {
            if (!_started)
            {
                await StartAsync(now, warmup);
            }

            var sinceLastTick = now - _lastTick;
            var timeAlive = now - StartTime;

            await OnTickAsync(GetClient(warmup), now, timeAlive, sinceLastTick, _tickNo);
            if (CheckSessionEnded(now))
            {
                await StopAsync(now, warmup);
                SessionEnded = true;
                return false;
            }

            _tickNo++;
            _lastTick = now;

            return true;
        }

        private async Task StopAsync(DateTime now, bool warmup)
        {
            Console.Write("Z");

            var timeAlive = now - StartTime;

            await OnStopAsync(GetClient(warmup), now, timeAlive);
        }

        protected async virtual Task OnStartAsync(IAnalyticsClient client, DateTime now)
        {
            _lastHeartBeatMsgSent = now + TimeSpan.Zero.WithRandomDeviation(3);

            if (_options.SessionStartMessage)
            {
                var msg = new SessionStart
                {
                    GamerTag = GamerTag,
                    GameSession = GameSession
                };

                await client.SendMessageAsync(msg, now);
            }
        }

        protected async virtual Task OnTickAsync(IAnalyticsClient client, DateTime now, TimeSpan timeAlive, TimeSpan sinceLastTick, long tickNo)
        {
            if (_options.HeartBeatMessageInterval > TimeSpan.Zero && now - _lastHeartBeatMsgSent >= _options.HeartBeatMessageInterval.WithRandomDeviation())
            {
                // Send HeartBeat msg if enough time has passed since
                var msg = new HeartBeat
                {
                    GameSession = GameSession
                };

                await client.SendMessageAsync(msg, now);

                _lastHeartBeatMsgSent = now;
            }
        }

        protected virtual Task OnStopAsync(IAnalyticsClient client, DateTime now, TimeSpan timeAlive)
        {
            _gamerTagProvider.ReturnGamerTag(GamerTag);

            return Task.CompletedTask;
        }

        protected virtual bool CheckSessionEnded(DateTime now)
        {
            return now - StartTime > _options.SessionLength;
        }
    }

    public class NetherBotOptions
    {
        public bool SessionStartMessage { get; set; } = true;
        public TimeSpan HeartBeatMessageInterval { get; set; } = TimeSpan.FromMinutes(1);
        public TimeSpan SessionLength { get; set; } = RandomEx.TimeSpan(TimeSpan.FromSeconds(5), TimeSpan.FromMinutes(20));
    }
}
