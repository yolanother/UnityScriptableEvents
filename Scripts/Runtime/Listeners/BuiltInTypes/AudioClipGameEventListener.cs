using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class AudioClipGameEventListener : GameEventListener<AudioClip, AudioClipGameEvent, AudioClipUnityEvent>
    {
        [SerializeField] private AudioClipGameEvent gameEvent;
        [SerializeField] private AudioClipUnityEvent onEvent = new AudioClipUnityEvent();

        public override AudioClipGameEvent GameEvent => gameEvent;
        public override AudioClipUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class AudioClipUnityEvent : UnityEvent<AudioClip>
    {
    }
}
