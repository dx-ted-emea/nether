﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Nether.Ingest
{
    public interface ITypeVersionMessage
    {
        string Type { get; }
        string Version { get; }
    }
}
