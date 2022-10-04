using System;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class EventHandler : Attribute
    {
        private string _field;
        public string Field => _field;
        
        public EventHandler(string field)
        {
            _field = field;
        }
    }
}