using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "DoubTech/Game Events/String Event")]
    [Serializable]
    public class StringGameEvent : GameEventT<string>
    {

    }
}
