﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LeaderboardLoadTest
{
    public class AutoPlayer
    {
        private static int s_counter;
        private readonly TextWriter _logger;
        private readonly string _password;
        private readonly string _username;
        private readonly Random _random = new Random();
        private readonly string _playerInternalId;
        private readonly Stopwatch _sw = new Stopwatch();
        private readonly NetherClient _client;
        private readonly Dictionary<string, List<long>> _callTimes = new Dictionary<string, List<long>>();

        public AutoPlayer(string username, string password, TextWriter logger)
        {
            _playerInternalId = (s_counter++).ToString();
            _playerInternalId = _playerInternalId.PadLeft(5, '0');

            _username = username;
            _password = password;
            _logger = logger;
            _client = new NetherClient();
        }

        public List<string> CallNames => _callTimes.Keys.ToList();

        public double GetAvgCallTime(string callName)
        {
            return _callTimes[callName].Average();
        }

        public double GetAvgCallsPerSecond(string callName)
        {
            List<long> lst = _callTimes[callName];

            return (double)lst.Count / TimeSpan.FromMilliseconds(lst.Sum()).TotalSeconds;
        }

        public string Id => _playerInternalId;

        public async Task PlayGameAsync(int callsPerUser, CancellationToken cancellationToken)
        {
            var response = await _client.LoginUserNamePasswordAsync(_username, _password);

            if (!response.IsSuccess)
            {
                _logger.WriteLine("Player({0}). Failed to log in, quitting: {1}", _playerInternalId, response.Message);
                return;
            }

            // simulate leaderboard activity
            int callsMade = 0;
            while (!cancellationToken.IsCancellationRequested && callsMade++ < callsPerUser)
            {
                //_logger.WriteLine("{0}: call {1}/{2}...", _playerInternalId, callsMade, callsPerUser);

                _sw.Restart();

                using (Measure("PostScore"))
                {
                    var callResult = await _client.PostScoreAsync(_random.Next());
                }

                using (Measure("GetScores"))
                {
                    var callResult = await _client.GetScoresAsync();
                }

                List<long> times;
                if(!_callTimes.TryGetValue("PostScore", out times))
                {
                    times = new List<long>();
                    _callTimes["PostScore"] = times;
                }
                times.Add(_sw.ElapsedMilliseconds);
            }

        }

        private IDisposable Measure(string callName)
        {
            return new InternalMeasure(callName, this);
        }

        class InternalMeasure : IDisposable
        {
            private string _callName;
            private AutoPlayer _master;

            public InternalMeasure(string callName, AutoPlayer master)
            {
                _callName = callName;
                _master = master;

                _master._sw.Restart();
            }

            public void Dispose()
            {
                _master._sw.Stop();

                List<long> times;
                if (!_master._callTimes.TryGetValue(_callName, out times))
                {
                    times = new List<long>();
                    _master._callTimes[_callName] = times;
                }
                times.Add(_master._sw.ElapsedMilliseconds);
            }
        }
    }
}
