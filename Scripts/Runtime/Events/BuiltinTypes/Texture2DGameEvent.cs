using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "Texture2DEvent", menuName = "DoubTech/Game Events/Built In Types/Texture2D Event")]
    [Serializable]
    public class Texture2DGameEvent : GameEvent<Texture2D>
    {

    }
}
