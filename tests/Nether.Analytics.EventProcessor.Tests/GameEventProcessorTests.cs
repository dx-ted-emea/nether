using Xunit;

namespace Nether.Analytics.EventProcessor.Tests
{
    public class GameEventProcessorTests
    {
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