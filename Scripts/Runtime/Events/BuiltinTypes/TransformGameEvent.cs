using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "TransformGameEvent", menuName = "DoubTech/Game Events/Built In Types/Transform Event")]
    [Serializable]
    public class TransformGameEvent : GameEvent<Transform>
    {

    }
}
