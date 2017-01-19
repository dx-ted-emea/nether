using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nether.Analytics.EventProcessor
{
    interface IBlobAppender
    {
        void Append(string eventType, params string[] columns);
    }

    class CsvBlobAppender : IBlobAppender
    {
        public void Append(string eventType, params string[] columns)
        {

        }
    }
}
