namespace TextEngine
{
    public class Event
    {
        public Event(string eventId, string promptId, int chance)
        {
            EventId = eventId;
            PromptId = promptId;
            this.Chance = chance;
        }
        
        // Getters
        public string EventId { get; }

        public string PromptId { get; }

        public int Chance { get; }
    }
}