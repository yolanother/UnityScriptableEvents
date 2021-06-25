using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class Vector3GameEventListener : GameEventListenerT<Vector3, Vector3GameEvent, Vector3UnityEvent>
    {
        [SerializeField] private Vector3GameEvent gameEvent;
        [SerializeField] private Vector3UnityEvent onEvent = new Vector3UnityEvent();

        public override Vector3GameEvent GameEvent => gameEvent;
        public override Vector3UnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class Vector3UnityEvent : UnityEvent<Vector3>
    {
    }
}
