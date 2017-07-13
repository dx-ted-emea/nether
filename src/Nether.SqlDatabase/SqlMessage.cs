// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Nether.SqlDatabase
{
    public class SqlMessage : SqlMessageBase
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public string EnqueuedTimeUtc { get; set; }
        public string Gamesession { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string GeoHash { get; set; }
        public string GeoHashPrecision { get; set; }
        public string GeoHashCenterLat { get; set; }
        public string GeoHashCenterLon { get; set; }
        public string GeoHashCenterDist { get; set; }
        public string Rnd { get; set; }

        public override string GetCreateTableQuery(string tableName)
        {
            return string.Format("create table {0} (Id varchar(100), MessageId varchar(100), Type varchar(100),  Version varchar(100), EnqueuedTimeUtc varchar(100), GameSession varchar(100), Lat varchar(100), Lon varchar(100), GeoHash varchar(100), GeoHashPrecision varchar(100), GeoHashCenterLat varchar(100), GeoHashCenterLon varchar(100), GeoHashCenterDist varchar(100), Rnd varchar(100))",
                tableName);
        }

        public override void SetProperties(Dictionary<string, string> properties)
        {
            MessageId = properties["id"];
            Type = properties["type"];
            Version = properties["version"];
            EnqueuedTimeUtc = properties["enqueuedTimeUtc"];
            Gamesession = properties["gameSession"];
            Lat = properties["lat"];
            Lon = properties["lon"];
            GeoHash = properties["geoHash"];
            GeoHashPrecision = properties["geoHashPrecision"];
            GeoHashCenterLat = properties["geoHashCenterLat"];
            GeoHashCenterLon = properties["geoHashCenterLon"];
            GeoHashCenterDist = properties["geoHashCenterDist"];
            Rnd = properties["rnd"];
        }
    }
}
