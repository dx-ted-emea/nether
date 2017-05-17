// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using Nether.Analytics.Logging;
using System;
using System.Threading.Tasks;

namespace Nether.Analytics
{
    public class DebugMessageHandler : IMessageHandler
    {
        private ILogger _logger { get; } = ApplicationLogging.CreateLogger<DebugMessageHandler>();

        public Task<MessageHandlerResults> ProcessMessageAsync(Message msg, string pipelineName, int idx)
        {
            _logger.LogDebug("DebugMessageHandler");
            _logger.LogDebug("-------------------");
            _logger.LogDebug($"Pipeline Name:  {pipelineName}");
            _logger.LogDebug($"Handler Idx:    {idx}");
            _logger.LogDebug(msg.ToString());

            return Task.FromResult(MessageHandlerResults.Success);
        }
    }
}