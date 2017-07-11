﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Nether.Ingest
{
    public class Message
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public DateTime EnqueuedTimeUtc { get; set; }
        public Dictionary<string, string> Properties { get; } = new Dictionary<string, string>();

        public string VersionedMessageType => GetVersionedMessageType(Type, Version);

        public override string ToString()
        {
            var str = new StringBuilder();

            str.AppendLine($"Id:             {Id}");
            str.AppendLine($"MessageType:    {Type}");
            str.AppendLine($"Version:        {Version}");
            str.AppendLine($"EnqueueTimeUtc: {EnqueuedTimeUtc}");
            str.AppendLine($"Properties:");

            foreach (var prop in Properties.Keys)
            {
                str.AppendLine($"    {prop}: {Properties[prop]}");
            }

            return str.ToString();
        }

        public static string GetVersionedMessageType(string messageType, string version)
        {
            return messageType + "_" + MessageVersion.Parse(version).Compatible;
        }
    }
}