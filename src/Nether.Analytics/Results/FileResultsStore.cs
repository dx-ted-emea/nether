// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
            _rootLocation = rootLocation;
        }

        public IResultsQuery For(string jobName)
        {
            // this method exists, to make querying the same store, but
            // for different jobs, easy-ish. Hence we create a query
            // object and configure it based on the parameters.
            // TODO: maybe do checking that pipeline is supported?
            return new FileResultsStoreQuery(this, jobName);
        }

        protected FileInfo GetLatest(string path, string searchPattern)
        {
            if (String.IsNullOrEmpty(path) || String.IsNullOrEmpty(_rootLocation)) return null;

            var directory = new DirectoryInfo(Path.Combine(_rootLocation, path));

            // we assume that the query already figured out the path *directly*
            // to the files, which means we can simply list all the files, order
            // them by last write time, and be done with it. If it didn't, then
            // it probably specified the search pattern, so we can use that
            var files = String.IsNullOrEmpty(searchPattern) ?
                directory.GetFiles() : directory.GetFiles(searchPattern);

            var lastFile = files.OrderByDescending(x => x.LastWriteTimeUtc).FirstOrDefault();
            return lastFile;
        }

        private class FileResultsStoreQuery : IResultsQuery
        {
            private FileResultsStore _store;
            private string _jobName;

            public FileResultsStoreQuery(FileResultsStore store, string jobName)
            {
                _store = store;
                _jobName = jobName;
            }

            public IResultSet Between(DateTime start, DateTime end)
            {
                throw new NotImplementedException();
            }

            public IResultSet Latest()
            {
                // TODO: remove this code, once we've established the naming is what
                // we expect.

                //// for the moment, we assume the pipeline specified the 
                //// path, and we can pass it directly
                //var fi = _store.GetLatest(_pipeline, null);

                var fi = _store.GetLatest(String.Empty,
                    GenerateFileSearchPattern(_jobName, null));

                if (fi == null)
                {
                    return new FileResultSet();
                }

                return new FileResultSet(new FileInfo[] { fi });
            }

            private string GenerateFileSearchPattern(string name, DateTime? dateTime)
            {
                if (dateTime.HasValue)
                {
                    throw new NotImplementedException();
                }

                return $"{name}_*";
            }



            private class FileResultSet : IResultSet
            {
                private FileInfo[] _files;

                public FileResultSet()
                {
                    // this is basically an empty set, but we can still deal with it
                    _files = new FileInfo[0];
                }

                public FileResultSet(FileInfo[] files)
                {
                    _files = files;
                }

                public string AsText()
                {
                    var stringBuilder = new StringBuilder();

                    foreach (var file in _files)
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
