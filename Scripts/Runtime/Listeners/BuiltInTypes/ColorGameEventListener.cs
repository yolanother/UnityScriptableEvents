using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [Serializable]
    public class
        ColorGameEventListener : GameEventListenerT<Color, ColorGameEvent, ColorUnityEvent>
    {
        [SerializeField] private ColorGameEvent gameEvent;
        [SerializeField] private ColorUnityEvent onEvent = new ColorUnityEvent();

        public override ColorGameEvent GameEvent => gameEvent;
        public override ColorUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class ColorUnityEvent : UnityEvent<Color>
    {
    }
}
