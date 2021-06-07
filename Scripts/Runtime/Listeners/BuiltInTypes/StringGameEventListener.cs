using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        StringGameEventListener : GameEventListenerT<string, StringEvent, StringUnityEvent>
    {
        [SerializeField] private StringEvent gameEvent;
        [SerializeField] private StringUnityEvent onEvent = new StringUnityEvent();

        public override StringEvent GameEvent => gameEvent;
        public override StringUnityEvent OnEvent => OnEvent;
    }

    [Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {
    }
}
