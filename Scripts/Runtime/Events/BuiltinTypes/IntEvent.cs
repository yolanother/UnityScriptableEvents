using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "IntEvent", menuName = "DoubTech/Game Events/Int Event")]
    [Serializable]
    public class IntEvent : GameEventT<int>
    {

    }
}
