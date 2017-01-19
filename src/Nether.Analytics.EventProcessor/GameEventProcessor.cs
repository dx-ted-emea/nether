using Microsoft.Azure.WebJobs.ServiceBus;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nether.Analytics.EventProcessor
{
    public class GameEventProcessor
    {
        private const string InputEventHubName = "analytics";
        private readonly IBlobAppender _appender;

        public GameEventProcessor() : this(new CsvBlobAppender())
        {
        }

        public GameEventProcessor(IBlobAppender appender)
        {
            this._appender = appender;
        }

        public void HandleOne([EventHubTrigger(InputEventHubName)] string data)
        {
            dynamic json = JsonConvert.DeserializeObject(data);

            var obj = JObject.Parse(data);

            var eventType = (string) obj["Event"];

            //this._appender.Append(eventType);
        }

        public bool ValidateData(JObject data)
        {
            return data["Event"] != null && data["Version"] != null && data["clientUtc"] != null;
        }

        //    var appender = new CsvBlobAppender();
        //    // DO MAGIC

        //public void HandleOne([EventHubTrigger("")] string data)

        //{
        //    dynamic json = JObject.Parse(data);

        //    json.Version

        //    appender.Append("start", json.Version, "Hello", "world");

        //}
    }
}