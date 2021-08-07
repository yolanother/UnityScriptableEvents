using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ColorGameEvent", menuName = "DoubTech/Game Events/Built In Types/Color Game Event")]
    [Serializable]
    public class ColorGameEvent : GameEvent<Color>
    {

    }
}
