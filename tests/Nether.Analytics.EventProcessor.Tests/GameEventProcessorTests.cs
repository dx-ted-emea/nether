using Newtonsoft.Json.Linq;
using Xunit;

namespace Nether.Analytics.EventProcessor.Tests
{
    public class GameEventProcessorTests
    {
        [Fact]
        public void DataValidationTest()
        {
            var sampleRequest =
                "{\"Event\":\"start\",\"Version\":\"1.0.0\",\"EventCorrelationId\":\"myRoom\",\"DurationName\":\"Room Open Length\",\"GameSessionId\":\"myRoom\",\"clientUtc\":\"2017-01-19T10:24:44.312943+00:00\"}";

            var processor = new GameEventProcessor();

            Assert.Equal(true, processor.ValidateData(JObject.Parse(sampleRequest)));

            Assert.Equal(false, processor.ValidateData(JObject.Parse("{}")));

            sampleRequest =
                "{\"Version\":\"1.0.0\",\"EventCorrelationId\":\"myRoom\",\"DurationName\":\"Room Open Length\",\"GameSessionId\":\"myRoom\",\"clientUtc\":\"2017-01-19T10:24:44.312943+00:00\"}";

            Assert.Equal(false, processor.ValidateData(JObject.Parse(sampleRequest)));

            sampleRequest =
               "{\"EventCorrelationId\":\"myRoom\",\"DurationName\":\"Room Open Length\",\"GameSessionId\":\"myRoom\",\"clientUtc\":\"2017-01-19T10:24:44.312943+00:00\"}";

            Assert.Equal(false, processor.ValidateData(JObject.Parse(sampleRequest)));

            sampleRequest =
               "{\"EventCorrelationId\":\"myRoom\",\"DurationName\":\"Room Open Length\",\"GameSessionId\":\"myRoom\",\"clientUtc\":\"2017-01-19T10:24:44.312943+00:00\"}";

            Assert.Equal(false, processor.ValidateData(JObject.Parse(sampleRequest)));

        }

        [Fact]
        public void DecodeInput()
        {
            var sampleRequest =
                "{\"Event\":\"start\",\"Version\":\"1.0.0\",\"EventCorrelationId\":\"myRoom\",\"DurationName\":\"Room Open Length\",\"GameSessionId\":\"myRoom\",\"clientUtc\":\"2017-01-19T10:24:44.312943+00:00\"}";

            var processor = new GameEventProcessor();

            processor.HandleOne(sampleRequest);
        }
    }
}