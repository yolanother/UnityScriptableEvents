using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "BoolEvent", menuName = "DoubTech/Game Events/Bool")]
    [Serializable]
    public class BoolGameEvent : GameEventT<bool> {}
}
