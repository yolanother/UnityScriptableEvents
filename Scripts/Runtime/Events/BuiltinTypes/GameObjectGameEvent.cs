using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{

    [CreateAssetMenu(fileName = "GameObjectGameEvent", menuName = "DoubTech/Game Events/Built In Types/Game Object Event")]
    [Serializable]
    public class GameObjectGameEvent : GameEvent<GameObject>
    {

    }
}
