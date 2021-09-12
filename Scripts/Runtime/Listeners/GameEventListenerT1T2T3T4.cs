using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class GameEventListener<T, T2, T3, T4, GAMEEVENT, UNITYEVENT> : MonoBehaviour,
        IGameEventListener<T, T2, T3, T4> where UNITYEVENT : UnityEvent<T, T2, T3, T4> where GAMEEVENT:
        GameEvent<T, T2, T3, T4>
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

        public virtual void Invoke(T a, T2 b, T3 c, T4 d)
        {
            GameEvent.Invoke(a, b, c, d);
        }

        public virtual void OnEventRaised(T a, T2 b, T3 c, T4 d)
        {
            OnEvent?.Invoke(a, b, c, d);
        }
    }


    public interface IGameEventListener<T1, T2, T3, T4>
    {
        void OnEventRaised(T1 a, T2 b, T3 c, T4 d);
    }
}
