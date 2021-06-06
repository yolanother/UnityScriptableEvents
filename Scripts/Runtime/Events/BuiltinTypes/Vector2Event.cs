using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "DoubTech/Game Events/Vector2 Event")]
    public class Vector2Event : GameEventT<Vector3>
    {

    }
}
