using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltTransformypes
{
    [Serializable]
    public class
        TransformGameEventListener : GameEventListener<Transform, TransformGameEvent, TransformUnityEvent>
    {
        [SerializeField] private TransformGameEvent gameEvent;
        [SerializeField] private TransformUnityEvent onEvent = new TransformUnityEvent();

        public override TransformGameEvent GameEvent => gameEvent;
        public override TransformUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class TransformUnityEvent : UnityEvent<Transform>
    {
    }
}
