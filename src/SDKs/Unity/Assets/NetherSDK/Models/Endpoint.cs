using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetherSDK.Models
{
    [Serializable]
    public class Endpoint
    {
        public string httpVerb;
        public string url;
        public string contentType;
        public string authorization;
        public string validUntilUtc;
    }
}
