using System;
using System.Collections.Generic;

namespace Nether.Analytics.Results
{
    /// <summary>
    /// Defines the common queries to be performed on a set of results.
    /// </summary>
    public interface IResultsQuery
    {
        /// <summary>
        /// Gets the latest set of results.
        /// </summary>
        /// <returns></returns>
         IResultSet Latest();

        /// <summary>
        /// Gets the set of results between (including) the specified 
        /// start and end date. 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        IResultSet Between(DateTime start, DateTime end);
    }
}
