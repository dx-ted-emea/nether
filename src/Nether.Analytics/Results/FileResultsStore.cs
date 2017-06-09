using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Nether.Analytics.Results
{
    // var resultsStore.For("dau").Latest().AsText();
    public class FileResultsStore : IResultsStore
    {
        private string _rootLocation;

        public FileResultsStore(string rootLocation)
        {
            this._rootLocation = rootLocation;
        }

        public IResultsQuery For(string pipeline)
        {
            // this method exists, to make querying the same store, but
            // for different pipelines, easy-ish. Hence we create a query
            // object and configure it based on the parameters.
            // TODO: maybe do checking that pipeline is supported?
            return new FileResultsStoreQuery(this, pipeline);
        }

        protected FileInfo GetLatest(string path, string searchPath)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(_rootLocation)) return null;

            var directory = new DirectoryInfo(Path.Combine(_rootLocation, path));

            // we assume that the query already figured out the path *directly*
            // to the files, which means we can simply list all the files, order
            // them by last write time, and be done with it
            var lastFile = directory.GetFiles().OrderByDescending(x => x.LastWriteTimeUtc).FirstOrDefault();
            return lastFile;
        }

        private class FileResultsStoreQuery : IResultsQuery
        {
            private FileResultsStore _store;
            private string _pipeline;

            public FileResultsStoreQuery(FileResultsStore store, string pipeline)
            {
                this._store = store;
                this._pipeline = pipeline;
            }

            public IResultSet Between(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public IResultSet Latest()
            {
                // for the moment, we assume the pipeline specified the 
                // path, and we can pass it directly
                var fi = _store.GetLatest(_pipeline);

                if (fi == null)
                {
                    return new FileResultSet();
                }

                return new FileResultSet(new FileInfo[] { fi });
            }

            

            private class FileResultSet : IResultSet
            {
                private FileInfo[] _files;

                public FileResultSet()
                {
                    // this is basically an empty set, but we can still deal with it
                    this._files = new FileInfo[0];
                }

                public FileResultSet(FileInfo[] files)
                {
                    this._files = files;
                }

                public string AsText()
                {
                    var stringBuilder = new StringBuilder();

                    foreach (var file in this._files)
                    {
                        // TODO: verify this assumption, of concating the files
                        // with a new line... it might not be the right thing always
                        stringBuilder.AppendLine(file.OpenText().ReadToEnd());
                    }

                    return stringBuilder.ToString();
                }
            }
        }
    }
}
