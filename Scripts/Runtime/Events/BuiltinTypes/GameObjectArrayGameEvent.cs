using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "GameObjectArrayGameEvent", menuName = "DoubTech/Game Events/Built In Types/Game Object Array Event")]
    [Serializable]
    public class GameObjectArrayGameEvent : GameEvent<GameObject[]>
    {

    }
}
