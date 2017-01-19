namespace Nether.Analytics.EventProcessor.Models
{
    public class CountEvent : GameEvent
    {
        public override string Event => "start";
        public override string Version => "1.0.0";
        public string CountName { get; set; }
        public string GameSessionId { get; set; }
    }
}