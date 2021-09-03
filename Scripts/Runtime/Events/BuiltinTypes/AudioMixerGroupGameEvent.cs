using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "AudioMixerGroupEvent", menuName = "DoubTech/Game Events/Built In Types/AudioMixerGroup Event")]
    [Serializable]
    public class AudioMixerGroupGameEvent : GameEvent<AudioMixerGroup>
    {

    }
}
