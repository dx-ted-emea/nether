using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nether.Common
{
    public static class ArgumentValidation
    {
        public static void EnsureNotNull(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, $"Parameter '{name}' must not be null");
            }
        }
    }
}
