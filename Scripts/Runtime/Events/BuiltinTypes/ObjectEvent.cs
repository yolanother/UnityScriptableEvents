using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ObjectEvent", menuName = "DoubTech/Game Events/Object Event")]
    [Serializable]
    public class ObjectEvent : GameEventT<Object>
    {

    }
}
