// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Configuration;

namespace Nether.Analytics.EventProcessor
{
    internal class NameResolver : INameResolver
    {
        public string Resolve(string name)
        {
            return Environment.GetEnvironmentVariable(name);
        }
    }
}
