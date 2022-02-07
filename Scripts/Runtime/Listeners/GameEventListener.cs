using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    [Serializable]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent response = new UnityEvent();
        
        [Header("Debugging")]
        [SerializeField] private bool debug;

        private IGameEventListenerValidator[] gameEventValidators;

        private ISimpleGameEventValidator[] gameEventValidatorsSimple;

        private IGenericGameEventValidator[] gameEventValidatorsGeneric;

        public UnityEvent OnEvent => response;

        private void OnEnable()
        {
            if (null == gameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            gameEvent.RegisterListener(this);
            gameEventValidators = GetComponents<IGameEventListenerValidator>();
            gameEventValidatorsSimple = GetComponents<ISimpleGameEventValidator>();
            gameEventValidatorsGeneric = GetComponents<IGenericGameEventValidator>();
        }

        private void OnDisable()
        {
            gameEvent.RegisterListener(this);
        }

        public virtual void OnEventRaised()
        {
            if (debug)
            {
                Debug.Log($"Event {gameEvent.name} raised.\n" + new Exception().StackTrace);
            }

            for (int i = 0; i < gameEventValidators.Length; i++)
            {
                var validator = gameEventValidators[i];
                try
                {
                    if (!validator.OnValidateEventListener(this)) return;
                }
                catch (Exception e)
                {
                    Debug.LogError(
                        $"Failed to execute {validator} on {name}. Illegal argument: {e.Message}");
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
                OnEvent?.Invoke();
            }
            catch (ArgumentException e)
            {
                Debug.LogError($"Failed to execute {gameEvent.name} on {name}. Illegal argument: {e.Message}");
            }
        }

        public void Invoke()
        {
            gameEvent.Invoke();
        }
    }
}
