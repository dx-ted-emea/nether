// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nether.Cosmos
{
    public class ScoreDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Country { get; set; }

        public int Score { get; set; }
    }
}
