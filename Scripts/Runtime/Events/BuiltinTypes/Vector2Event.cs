using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "DoubTech/Game Events/Vector2 Event")]
    [Serializable]
    public class Vector2Event : GameEventT<Vector2>
    {

    }
}
