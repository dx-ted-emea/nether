// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Nether.Analytics.Results
{
    public interface IResultSet
    {
        /// <summary>
        /// Returns the entire result set as one (potentially) huge string.
        /// </summary>
        /// <returns></returns>
        string AsText();
    }
}
