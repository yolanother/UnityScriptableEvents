using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class StringGameEventListener : GameEventListenerT<string, StringGameEvent, StringUnityEvent>
    {
        [SerializeField] private StringGameEvent gameEvent;
        [SerializeField] private StringUnityEvent onEvent = new StringUnityEvent();

        public override StringGameEvent GameEvent => gameEvent;
        public override StringUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {
    }
}
