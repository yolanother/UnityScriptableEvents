using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    [CreateAssetMenu(fileName = "GameEventSet", menuName = "DoubTech/Game Events/Game Event Set")]
    public class GameEventSet : ScriptableObject
    {
        public BaseGameEvent[] events;
        [Tooltip("These are events that are read from child class properties.")]
        public BaseGameEvent[] propertyEvents;
        private Dictionary<string, BaseGameEvent> eventMap;
        public BaseGameEvent this[string eventName]
        {
            get
            {
                if (null == eventMap)
                {
                    eventMap = new Dictionary<string, BaseGameEvent>();
                    foreach (var e in propertyEvents)
                    {
                        eventMap[e.name] = e;
                    }

                    foreach (var e in events)
                    {
                        eventMap[e.name] = e;
                    }
                }

                if (!eventMap.TryGetValue(eventName, out var gameEvent))
                {
                    throw new Exception($"{eventName} has not been defined in {name}");
                }
                return gameEvent;
            }
        }

        protected virtual void OnValidate()
        {
            List<BaseGameEvent> events = new List<BaseGameEvent>();
            Type t = GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                try
                {
                    var value = field.GetValue(this);
                    if (value is BaseGameEvent e) events.Add(e);
                }
                catch (ArgumentException)
                {
                    // Ignore this field
                }
            }

            this.propertyEvents = events.ToArray();
            eventMap = null;
        }
    }
}
