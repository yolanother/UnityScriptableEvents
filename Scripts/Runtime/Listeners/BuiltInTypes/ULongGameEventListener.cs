using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        ULongGameEventListener : GameEventListener<ulong, ULongGameEvent, ULongUnityEvent>
    {
        [SerializeField] private ULongGameEvent gameEvent;
        [SerializeField] private ULongUnityEvent onEvent = new ULongUnityEvent();

        public override ULongGameEvent GameEvent => gameEvent;
        public override ULongUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class ULongUnityEvent : UnityEvent<ulong>
    {
    }
}
