﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Nether.Data.Sql.Analytics
{
    public class YearlyLevelDropOffEntity
    {
        public int Year { get; set; }
        public int ReachedLevel { get; set; }
        public long TotalCount { get; set; }
    }
}

