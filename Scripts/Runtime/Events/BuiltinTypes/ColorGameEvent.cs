using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "ColorGameEvent", menuName = "DoubTech/Game Events/Color Game Event")]
    [Serializable]
    public class ColorGameEvent : GameEventT<Color>
    {

    }
}
