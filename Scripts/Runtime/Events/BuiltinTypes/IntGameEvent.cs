using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "IntGameEvent", menuName = "DoubTech/Game Events/Int Game Event")]
    [Serializable]
    public class IntGameEvent : GameEventT<int>
    {

    }
}
