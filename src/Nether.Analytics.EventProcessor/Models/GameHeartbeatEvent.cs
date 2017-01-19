namespace Nether.Analytics.EventProcessor.Models
{
    public class GameHeartbeatEvent : GameEvent
    {
        public override string Event => "start";
        public override string Version => "1.0.0";  
        public string GameSessionId { get; set; }
    }
}