using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    public class BoolGameEventListener : GameEventListenerT<bool, BoolGameEvent, BoolUnityEvent>
    {
        [SerializeField] private BoolGameEvent gameEvent;
        [SerializeField] private BoolUnityEvent onEvent = new BoolUnityEvent();

        public override BoolGameEvent GameEvent => gameEvent;
        public override BoolUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {
    }
}
