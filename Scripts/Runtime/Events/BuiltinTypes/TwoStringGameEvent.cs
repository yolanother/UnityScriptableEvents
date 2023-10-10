using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "TwoStringEvent", menuName = "DoubTech/Game Events/Built In Types/Two String Event")]
    [Serializable]
    public class TwoStringGameEvent : GameEvent<string, string>
    {

    }
}
