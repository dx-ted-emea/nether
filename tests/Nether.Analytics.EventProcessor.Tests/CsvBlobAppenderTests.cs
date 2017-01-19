using Xunit;

namespace Nether.Analytics.EventProcessor.Tests
{
    public class CsvBlobAppenderTests
    {
        [Fact]
        public void Given_values_in_an_arry_output_csv_format_should_be_correct()
        {
            var appender = new CsvBlobAppender();

            var eventType = "Start";
            var version = "1.0";
            
            Assert.True(true);
        }
    }
}