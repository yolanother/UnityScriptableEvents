using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "ThreeStringEvent", menuName = "DoubTech/Game Events/Built In Types/Three String Event")]
    [Serializable]
    public class ThreeStringGameEvent : GameEvent<string, string, string>
    {

    }
}
