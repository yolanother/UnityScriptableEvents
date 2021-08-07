using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ObjectGameEvent", menuName = "DoubTech/Game Events/Built In Types/Object Event")]
    [Serializable]
    public class ObjectGameEvent : GameEvent<Object>
    {

    }
}
