using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "DoubTech/Game Events/Built In Types/Bool")]
    [Serializable]
    public class BoolGameEvent : GameEvent<bool> {}
}
