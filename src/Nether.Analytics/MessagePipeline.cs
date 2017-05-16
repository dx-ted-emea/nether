﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;

namespace Nether.Analytics
{
    public class MessagePipeline
    {
        private IMessageHandler[] _gameEventHandlers;
        private IOutputManager[] _outputManagers;

        public string PipelineName { get; private set; }
        public VersionedMessageType[] HandledMessageTypes { get; private set; }

        public MessagePipeline(string pipelineName,
            VersionedMessageType[] handledMessageTypes,
            IMessageHandler[] gameEventHandlers,
            IOutputManager[] outputManagers)
        {
            PipelineName = pipelineName;
            HandledMessageTypes = handledMessageTypes;
            _gameEventHandlers = gameEventHandlers;
            _outputManagers = outputManagers;
        }

        public async Task ProcessMessageAsync(Message msg)
        {
            var handlerIdx = 0;
            foreach (var handler in _gameEventHandlers)
            {
                var result = await handler.ProcessMessageAsync(msg, PipelineName, handlerIdx++);
                if (result == MessageHandlerResults.FailStopProcessing)
                {
                    //add an error property to the message
                    msg.Properties.Add(Constants.Error, Constants.ErrorInMessageProcessing);
                    //TODO: do something better here
                    return;
                }
            }

            //TODO: Run output managers in parallel
            var outputManagerIdx = 0;
            foreach (var outputManager in _outputManagers)
            {
                await outputManager.OutputMessageAsync(PipelineName, outputManagerIdx++, msg);
            }
        }
    }
}