using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "String Array Event", menuName = "DoubTech/Game Events/Built In Types/String Array Event")]
    [Serializable]
    public class StringArrayGameEvent : GameEvent<string[]>
    {

    }
}
