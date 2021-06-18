using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class Vector2GameEventListener : GameEventListenerT<Vector2, Vector2GameEvent, Vector2UnityEvent>
    {
        [SerializeField] private Vector2GameEvent gameEvent;
        [SerializeField] private Vector2UnityEvent onEvent = new Vector2UnityEvent();

        public override Vector2GameEvent GameEvent => gameEvent;
        public override Vector2UnityEvent OnEvent => OnEvent;
    }

    [Serializable]
    public class Vector2UnityEvent : UnityEvent<Vector2>
    {
    }
}
