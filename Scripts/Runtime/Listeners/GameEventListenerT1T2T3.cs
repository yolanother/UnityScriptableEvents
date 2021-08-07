using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class GameEventListener<T, T2, T3, GAMEEVENT, UNITYEVENT> : MonoBehaviour,
        IGameEventListener<T, T2, T3> where UNITYEVENT : UnityEvent<T, T2, T3> where GAMEEVENT:
        GameEvent<T, T2, T3>
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

        public virtual void Invoke(T a, T2 b, T3 c)
        {
            GameEvent.Invoke(a, b, c);
        }

        public virtual void OnEventRaised(T a, T2 b, T3 c)
        {
            OnEvent?.Invoke(a, b, c);
        }
    }


    public interface IGameEventListener<T1, T2, T3>
    {
        void OnEventRaised(T1 a, T2 b, T3 c);
    }
}
