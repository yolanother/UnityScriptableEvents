using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class StringArrayGameEventListener : GameEventListener<string[], StringArrayGameEvent, StringArrayUnityEvent>
    {
        [SerializeField] private StringArrayGameEvent gameEvent;
        [SerializeField] private StringArrayUnityEvent onEvent = new StringArrayUnityEvent();

        public override StringArrayGameEvent GameEvent => gameEvent;
        public override StringArrayUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class StringArrayUnityEvent : UnityEvent<string[]>
    {
    }
}
