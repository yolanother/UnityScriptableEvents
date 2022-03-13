using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class
        CameraGameEventListener : GameEventListener<Camera, CameraGameEvent, CameraUnityEvent>
    {
        [SerializeField] private CameraGameEvent gameEvent;
        [SerializeField] private CameraUnityEvent onEvent = new CameraUnityEvent();

        public override CameraGameEvent GameEvent => gameEvent;
        public override CameraUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class CameraUnityEvent : UnityEvent<Camera>
    {
    }
}
