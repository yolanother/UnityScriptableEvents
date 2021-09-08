using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class Texture2DGameEventListener : GameEventListener<Texture2D, Texture2DGameEvent, Texture2DUnityEvent>
    {
        [SerializeField] private Texture2DGameEvent gameEvent;
        [SerializeField] private Texture2DUnityEvent onEvent = new Texture2DUnityEvent();

        public override Texture2DGameEvent GameEvent => gameEvent;
        public override Texture2DUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class Texture2DUnityEvent : UnityEvent<Texture2D>
    {
    }
}
