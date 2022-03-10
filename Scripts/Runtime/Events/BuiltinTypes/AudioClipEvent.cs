using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "AudioClipGameEvent", menuName = "DoubTech/Game Events/Built In Types/AudioClip Game Event")]
    [Serializable]
    public class AudioClipGameEvent : GameEvent<AudioClip>
    {

    }
}
