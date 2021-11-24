using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltGameObjectypes
{
    [Serializable]
    public class
        GameObjectGameEventListener : GameEventListener<GameObject, GameObjectGameEvent, GameObjectUnityEvent>
    {
        [SerializeField] private GameObjectGameEvent gameEvent;
        [SerializeField] private GameObjectUnityEvent onEvent = new GameObjectUnityEvent();

        public override GameObjectGameEvent GameEvent => gameEvent;
        public override GameObjectUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class GameObjectUnityEvent : UnityEvent<GameObject>
    {
    }
}
