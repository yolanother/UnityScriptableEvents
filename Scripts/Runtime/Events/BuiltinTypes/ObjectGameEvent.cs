using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ObjectGameEvent", menuName = "DoubTech/Game Events/Object Event")]
    [Serializable]
    public class ObjectGameEvent : GameEventT<Object>
    {

    }
}
