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

        private IGameEventListenerValidator<T>[] gameEventValidators;

        private ISimpleGameEventValidator[] gameEventValidatorsSimple;

        private IGenericGameEventValidator[] gameEventValidatorsGeneric;

        protected virtual void OnEnable()
        {
            if (null == GameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            GameEvent.RegisterListener(this);
            gameEventValidators = GetComponents<IGameEventListenerValidator<T>>();
            gameEventValidatorsSimple = GetComponents<ISimpleGameEventValidator>();
            gameEventValidatorsGeneric = GetComponents<IGenericGameEventValidator>();
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

            for (int i = 0; null != gameEventValidators && i < gameEventValidators.Length; i++)
            {
                var validator = gameEventValidators[i];
                try
                {
                    if (!validator.OnValidateEventListener(this, t)) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} ({typeof(T).Name} = {t}) on {name}. Illegal argument: {e.Message}");
                    throw;
                }
            }

            for (int i = 0; null != gameEventValidatorsGeneric && i < gameEventValidatorsGeneric.Length; i++)
            {
                var validator = gameEventValidatorsGeneric[i];
                try
                {
                    if (!validator.OnValidateEvent(this)) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} on {name}. Illegal argument: {e.Message}");
                    throw;
                }
            }

            for (int i = 0; null != gameEventValidatorsSimple && i < gameEventValidatorsSimple.Length; i++)
            {
                var validator = gameEventValidatorsSimple[i];
                try
                {
                    if (!validator.OnValidateEvent()) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} on {name}. Illegal argument: {e.Message}");
                    throw;
                }
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
