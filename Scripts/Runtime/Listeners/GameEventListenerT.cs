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
        [SerializeField] private bool debug;

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
            if (debug)
            {
                Debug.Log($"Event {GameEvent.name} raised.\n" + new Exception().StackTrace);
            }
            try
            {
                OnEvent?.Invoke(t);
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Failed to execute {GameEvent.name} ({typeof(T).Name} = {t}) on {name}. Illegal argument: {e.Message}");
            }
        }
    }

    public interface IGameEventListenerT<T>
    {
        void OnEventRaised(T a);
    }
}
