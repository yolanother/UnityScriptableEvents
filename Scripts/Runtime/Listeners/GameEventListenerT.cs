using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class GameEventListenerT<T, GAMEEVENT, UNITYEVENT> : MonoBehaviour,
        IGameEventListenerT<T> where UNITYEVENT : UnityEvent<T> where GAMEEVENT: GameEventT<T>
    {
        public abstract GAMEEVENT GameEvent { get; }
        public abstract UNITYEVENT OnEvent { get; }

        protected virtual void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        protected virtual void OnDisable()
        {
            GameEvent.RegisterListener(this);
        }

        public void Invoke(T t)
        {
            GameEvent.Invoke(t);
        }

        public void OnEventRaised(T t)
        {
            OnEvent?.Invoke(t);
        }
    }

    public interface IGameEventListenerT<T>
    {
        void OnEventRaised(T a);
    }
}
