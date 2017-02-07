// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Diagnostics;

namespace Nether.Data.Analytics
{
    [DebuggerDisplay("RawDataFile (name '{Name}')")]
    public class RawDataFile
    {
        public string Name { get; set; }

        public string Url { get; set; }

    }
}
