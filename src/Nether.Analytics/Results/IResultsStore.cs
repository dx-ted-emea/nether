namespace Nether.Analytics.Results
{
    /// <summary>
    /// Defines the interface for communicating with the results store. 
    /// </summary>
    public interface IResultsStore
    {
        /// <summary>
        /// Gets the result query for a specific pipeline.
        /// </summary>
        /// <param name="pipeline"></param>
        /// <returns>Returns a query object, configured for the specified store, and specified pipeline.</returns>
        IResultsQuery For(string pipeline);
    }
}
