using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class GameEventListener<T, GAMEEVENT, UNITYEVENT> : MonoBehaviour,
        IGameEventListenerT<T> where UNITYEVENT : UnityEvent<T> where GAMEEVENT: GameEvent<T>
    {
        public abstract GAMEEVENT GameEvent { get; }
        public abstract UNITYEVENT OnEvent { get; }

        protected virtual void OnEnable()
        {
            if (null == GameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            GameEvent.RegisterListener(this);
        }

        protected virtual void OnDisable()
        {
            GameEvent.RegisterListener(this);
        }

        public virtual void Invoke(T t)
        {
            GameEvent.Invoke(t);
        }

        public virtual void OnEventRaised(T t)
        {
            OnEvent?.Invoke(t);
        }
    }

    public interface IGameEventListenerT<T>
    {
        void OnEventRaised(T a);
    }
}
