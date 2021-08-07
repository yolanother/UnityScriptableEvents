using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "IntGameEvent", menuName = "DoubTech/Game Events/Built In Types/Int Game Event")]
    [Serializable]
    public class IntGameEvent : GameEvent<int>
    {

    }
}
