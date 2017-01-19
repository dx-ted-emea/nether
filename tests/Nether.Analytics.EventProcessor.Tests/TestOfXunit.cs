using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Nether.Analytics.EventProcessor.Logic.Tests
{
    public class TestOfXunit
    {
        [Fact]
        public void Test()
        {
            var x = new NetherInputEventHubProcessor();

            Assert.Equal(1, x.TestOfTest());
            
        }
    }
}
