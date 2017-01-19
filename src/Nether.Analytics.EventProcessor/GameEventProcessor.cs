using Microsoft.Azure.WebJobs.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nether.Analytics.EventProcessor
{
    public class GameEventProcessor
    {
        private const string InputEventHubName = "analytics";

        public void HandleOne([EventHubTrigger(InputEventHubName)] string data)
        {
            dynamic json = JsonConvert.DeserializeObject(data);
        }

        //public void HandleOne([EventHubTrigger("")] string data)

        //{
        //    dynamic json = JObject.Parse(data);

        //    json.Version
        //    // DO MAGIC
        //    var appender = new CsvBlobAppender();

        //    appender.Append("start", json.Version, "Hello", "world");

        //}
    }
}