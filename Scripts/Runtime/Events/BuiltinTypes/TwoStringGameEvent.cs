using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "TwoStringEvent", menuName = "DoubTech/Game Events/Built In Types/Two String Event")]
    [Serializable]
    public class TwotringGameEvent : GameEvent<string, string, string>
    {

    }
}
