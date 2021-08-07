using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "DoubTech/Game Events/Built In Types/String Event")]
    [Serializable]
    public class StringGameEvent : GameEvent<string>
    {

    }
}
