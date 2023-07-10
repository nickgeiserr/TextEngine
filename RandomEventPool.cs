using System;
using System.Collections.Generic;

namespace TextEngine
{
    public class RandomEventPool
    {
        private readonly string _eventPoolId;
        private readonly List<Event> _events;
        private readonly Random _random;

        public RandomEventPool(List<Event> events, string eventPoolId)
        {
            _events = events ?? throw new ArgumentNullException(nameof(events));
            _eventPoolId = eventPoolId;
            _random = new Random();
        }

        public List<Event> PollEvents()
        {
            List<Event> eventsToPoll = new List<Event>();
            
            foreach (Event evt in _events)
            {
                int chance = _random.Next(1, 101);
                if (chance <= evt.Chance)
                {
                    eventsToPoll.Add(evt);
                }
            }

            return eventsToPoll;
        }
        
        // Getters
        public string GetEventPoolId()
        {
            return _eventPoolId;
        }

        public List<Event> GetEventList()
        {
            return _events;
        }
    }
}