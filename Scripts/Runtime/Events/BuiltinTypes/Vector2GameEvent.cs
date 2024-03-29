﻿using System;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CreateAssetMenu(fileName = "Vector2Event", menuName = "DoubTech/Game Events/Built In Types/Vector2 Event")]
    [Serializable]
    public class Vector2GameEvent : GameEvent<Vector2>
    {

    }
}
