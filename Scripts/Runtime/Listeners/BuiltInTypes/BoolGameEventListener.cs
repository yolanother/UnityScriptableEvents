using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    public class
        BoolGameEventListener : GameEventListenerT<bool, BoolEvent, BoolUnityEvent>
    {
        [SerializeField] private BoolEvent gameEvent;
        [SerializeField] private BoolUnityEvent onEvent = new BoolUnityEvent();

        public override BoolEvent GameEvent => gameEvent;
        public override BoolUnityEvent OnEvent => OnEvent;
    }

    [Serializable]
    public class BoolUnityEvent : UnityEvent<bool>
    {
    }
}
