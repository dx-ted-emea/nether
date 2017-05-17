// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nether.Analytics.Logging
{
    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory()
            .AddConsole()
            .AddDebug();

        public static ILogger CreateLogger<T>() =>
            LoggerFactory.CreateLogger<T>();
    }
}
