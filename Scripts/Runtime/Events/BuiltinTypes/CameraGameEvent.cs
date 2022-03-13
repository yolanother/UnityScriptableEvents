using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "CameraGameEvent", menuName = "DoubTech/Game Events/Built In Types/Camera Event")]
    [Serializable]
    public class CameraGameEvent : GameEvent<Camera>
    {

    }
}