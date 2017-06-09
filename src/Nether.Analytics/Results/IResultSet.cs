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
