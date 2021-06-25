using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        IntGameEventListener : GameEventListenerT<int, IntEvent, IntUnityEvent>
    {
        [SerializeField] private IntEvent gameEvent;
        [SerializeField] private IntUnityEvent onEvent = new IntUnityEvent();

        public override IntEvent GameEvent => gameEvent;
        public override IntUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {
    }
}
