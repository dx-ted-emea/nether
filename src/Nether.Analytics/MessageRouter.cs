﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using Nether.Analytics.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nether.Analytics
{
    public class MessageRouter : IMessageRouter
    {
        private Dictionary<string, List<MessagePipeline>> _routingDictionary = new Dictionary<string, List<MessagePipeline>>();

        private ILogger _logger { get; } = ApplicationLogging.CreateLogger<MessageRouter>();
        //private MessagePipeline _unhandledEventPipeline;

        public MessageRouter(List<MessagePipeline> messagePipelines)
        {
            foreach (var pipeline in messagePipelines)
            {
                foreach (var messageType in pipeline.HandledMessageTypes)
                {
                    if (_routingDictionary.TryGetValue(messageType.Key, out var existingPipelinesForMessageType))
                    {
                        existingPipelinesForMessageType.Add(pipeline);
                    }
                    else
                    {
                        var newPipelinesForMessageType = new List<MessagePipeline>();
                        newPipelinesForMessageType.Add(pipeline);
                        _routingDictionary.Add(messageType.Key, newPipelinesForMessageType);
                    }
                }
            }

            //_unhandledEventPipeline = unhandledEventPipeline;
        }

        public async Task RouteMessageAsync(Message msg)
        {
            //TODO: Fix Message Key to something more elegant
            var versionedMessageType = new VersionedMessageType { MessageType = msg.MessageType, Version = msg.Version };

            if (_routingDictionary.TryGetValue(versionedMessageType.Key, out var pipelines))
            {
                //TODO: Run loop in parallel
                foreach (var pipeline in pipelines)
                {
                    await pipeline.ProcessMessageAsync(msg);
                }
            }
            else
            {
                _logger.LogInformation($"No pipeline found for message type: {msg.MessageType}, version: {msg.Version}");
                //TODO Implement unhandled pipeline here
                //await _unhandledEventPipeline?.ProcessMessageAsync(msg);
            }
        }
    }
}