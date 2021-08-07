using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        IntGameEventListener : GameEventListener<int, IntGameEvent, IntUnityEvent>
    {
        [SerializeField] private IntGameEvent gameEvent;
        [SerializeField] private IntUnityEvent onEvent = new IntUnityEvent();

        public override IntGameEvent GameEvent => gameEvent;
        public override IntUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class IntUnityEvent : UnityEvent<int>
    {
    }
}
