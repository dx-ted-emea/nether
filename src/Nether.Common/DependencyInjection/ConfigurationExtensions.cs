// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Common.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static bool Exists(this IConfiguration configuration, string key)
        {
            string test = configuration[key];
            return !string.IsNullOrEmpty(test);
        }
    }
}

