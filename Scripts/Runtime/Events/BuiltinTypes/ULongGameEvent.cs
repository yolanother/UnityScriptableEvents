using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ULongGameEvent", menuName = "DoubTech/Game Events/Built In Types/ULong Game Event")]
    [Serializable]
    public class ULongGameEvent : GameEvent<ulong>
    {

    }
}
