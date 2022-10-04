using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class GeneralGameEventListener : MonoBehaviour
    {
        public BaseGameEvent GameEvent;
        public GeneralUnityEvent OnEvent;
        
        [Header("Debugging")]
        [SerializeField] private bool debug;

        private IGameEventListenerValidator<object[]>[] gameEventValidators;

        private ISimpleGameEventValidator[] gameEventValidatorsSimple;

        private IGenericGameEventValidator[] gameEventValidatorsGeneric;

        protected virtual void OnEnable()
        {
            if (null == GameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            GameEvent.RegisterGeneralListener(this);
            gameEventValidators = GetComponents<IGameEventListenerValidator<object[]>>();
            gameEventValidatorsSimple = GetComponents<ISimpleGameEventValidator>();
            gameEventValidatorsGeneric = GetComponents<IGenericGameEventValidator>();
        }

        protected virtual void OnDisable()
        {
            GameEvent.UnregisterGeneralListener(this);
        }

        public virtual void Invoke(params object[] args)
        {
            GameEvent.InvokeGeneric(args);
        }

        public virtual void OnEventRaised(object[] t)
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
                    if (!validator.OnValidateEventListener(this, t)) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} ({t}) on {name}. Illegal argument: {e.Message}");
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
                OnEvent?.Invoke(t);
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Failed to execute {GameEvent.name} ({t}) on {name}. Illegal argument: {e.Message}");
            }
        }
    }

    [Serializable]
    public class GeneralUnityEvent : UnityEvent<object[]>
    {
    }
}
