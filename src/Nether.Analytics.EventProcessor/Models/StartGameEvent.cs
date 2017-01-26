namespace Nether.Analytics.EventProcessor.Models
{
    public class StartGameEvent : GameEvent
    {
        public override string Event => "game-start";
        public override string Version => "1.0.0";
        public string GameSessionId { get; set; }
        public string Gamertag { get; set; }
    }
}