using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class AudioMixerGroupGameEventListener : GameEventListener<AudioMixerGroup, AudioMixerGroupGameEvent, AudioMixerGroupUnityEvent>
    {
        [SerializeField] private AudioMixerGroupGameEvent gameEvent;
        [SerializeField] private AudioMixerGroupUnityEvent onEvent = new AudioMixerGroupUnityEvent();

        public override AudioMixerGroupGameEvent GameEvent => gameEvent;
        public override AudioMixerGroupUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class AudioMixerGroupUnityEvent : UnityEvent<AudioMixerGroup>
    {
    }
}
