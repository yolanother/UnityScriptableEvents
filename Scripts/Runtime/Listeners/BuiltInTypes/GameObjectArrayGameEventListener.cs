using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltGameObjectypes
{
    [Serializable]
    public class
        GameObjectArrayGameEventListener : GameEventListener<GameObject[], GameObjectArrayGameEvent, GameObjectArrayUnityEvent>
    {
        [SerializeField] private GameObjectArrayGameEvent gameEvent;
        [SerializeField] private GameObjectArrayUnityEvent onEvent = new GameObjectArrayUnityEvent();

        public override GameObjectArrayGameEvent GameEvent => gameEvent;
        public override GameObjectArrayUnityEvent OnEvent => onEvent;
    }

    [Serializable]
    public class GameObjectArrayUnityEvent : UnityEvent<GameObject[]>
    {
    }
}
