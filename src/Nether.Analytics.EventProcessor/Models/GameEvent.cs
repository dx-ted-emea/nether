using System;

namespace Nether.Analytics.EventProcessor.Models
{
    public abstract class GameEvent
    {
        public abstract string Event { get; }
        public abstract string Version { get; }
        public DateTime ClientUtc { get; set; }
    }
}