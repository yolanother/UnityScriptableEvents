using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class GameEventListener<T, T2, GAMEEVENT, UNITYEVENT> : MonoBehaviour,
        IGameEventListener<T, T2> where UNITYEVENT : UnityEvent<T, T2> where GAMEEVENT:
        GameEvent<T, T2>
    {
        public abstract GAMEEVENT GameEvent { get; }
        public abstract UNITYEVENT OnEvent { get; }
        [SerializeField] private bool debug;

        private IGameEventListenerValidator<T, T2>[] gameEventValidators;

        private ISimpleGameEventValidator[] gameEventValidatorsSimple;

        private IGenericGameEventValidator[] gameEventValidatorsGeneric;

        protected virtual void OnEnable()
        {
            if (null == GameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            GameEvent.RegisterListener(this);
            gameEventValidators = GetComponents<IGameEventListenerValidator<T, T2>>();
            gameEventValidatorsSimple = GetComponents<ISimpleGameEventValidator>();
            gameEventValidatorsGeneric = GetComponents<IGenericGameEventValidator>();
        }

        protected virtual void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public virtual void Invoke(T a, T2 b)
        {
            GameEvent.Invoke(a, b);
        }

        public virtual void OnEventRaised(T a, T2 b)
        {
            if (debug)
            {
                Debug.Log($"Event {GameEvent.name} raised.\n" + new Exception().StackTrace);
            }

            for (int i = 0; i < gameEventValidators.Length; i++)
            {
                var validator = gameEventValidators[i];
                try
                {
                    if (!validator.OnValidateEventListener(this, a, b)) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} ({typeof(T).Name} = {a}, {b}) on {name}. Illegal argument: {e.Message}");
                    throw;
                }
            }

            for (int i = 0; i < gameEventValidatorsGeneric.Length; i++)
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

            for (int i = 0; i < gameEventValidatorsSimple.Length; i++)
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
                OnEvent?.Invoke(a, b);
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Failed to execute {GameEvent.name} ({typeof(T).Name} = {a}, {b}) on {name}. Illegal argument: {e.Message}");
            }
        }
    }


    public interface IGameEventListener<T1, T2>
    {
        void OnEventRaised(T1 a, T2 b);
    }
}
