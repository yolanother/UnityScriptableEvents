using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class FloatGameEventListener : GameEventListenerT<float, FloatGameEvent, FloatUnityEvent>
    {
        [SerializeField] private FloatGameEvent gameEvent;
        [SerializeField] private FloatUnityEvent onEvent = new FloatUnityEvent();

        public override FloatGameEvent GameEvent => gameEvent;
        public override FloatUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class FloatUnityEvent : UnityEvent<float>
    {
    }
}
