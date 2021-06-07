using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        FloatGameEventListener : GameEventListenerT<float, FloatEvent, FloatUnityEvent>
    {
        [SerializeField] private FloatEvent gameEvent;
        [SerializeField] private FloatUnityEvent onEvent = new FloatUnityEvent();

        public override FloatEvent GameEvent => gameEvent;
        public override FloatUnityEvent OnEvent => OnEvent;
    }

    [Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {
    }
}
