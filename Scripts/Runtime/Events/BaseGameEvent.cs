using System;
using System.Collections.Generic;
using System.Net;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public abstract class BaseGameEvent : ScriptableObject
    {
        [Tooltip("If an event has already been received store the data for that event and when a new register/add is called immediately return that value")]
        [SerializeField] protected bool reusePastEvent;

        [Header("Debugging")]
        [SerializeField] private bool debugInvoke;

#if ODIN_INSPECTOR
        [ReadOnly]
        [ShowInInspector]
#endif
        protected bool eventTriggered;

        protected List<GeneralGameEventListener> generalGameEventListeners = new List<GeneralGameEventListener>();
        protected List<GeneralListenerAction> generalListenerActions = new List<GeneralListenerAction>();
        protected List<Action<object[]>> actionListenersObjects = new List<Action<object[]>>();
        
        /// <summary>
        /// Clears the event triggered flag and any associated data that may have come with that event.
        /// </summary>
        public virtual void ClearData()
        {
            eventTriggered = false;
        }

        public void AddGeneralListener(GeneralListenerAction action, bool allowDuplicate = false)
        {
            if (allowDuplicate || !generalListenerActions.Contains(action))
            {
                generalListenerActions.Insert(0, action);
                if(reusePastEvent && eventTriggered)
                {
                    OnReInvokeGeneric(action);
                }
            }
        }

        protected virtual void OnReInvokeGeneric(GeneralGameEventListener listener)
        {
            listener.Invoke(Array.Empty<object>());
        }

        protected virtual void OnReInvokeGeneric(GeneralListenerAction action)
        {
            action.listener.Invoke(action, Array.Empty<object>());
        }

        public void RemoveGeneralListener(GeneralListenerAction listener)
        {
            generalListenerActions.Remove(listener);
        }

        public void RegisterGeneralListener(GeneralGameEventListener listener,
            bool allowDuplicate = false)
        {
            if (allowDuplicate || !generalGameEventListeners.Contains(listener))
            {
                generalGameEventListeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    OnReInvokeGeneric(listener);
                }
            }
        }

        public void UnregisterGeneralListener(GeneralGameEventListener listener)
        {
            generalGameEventListeners.Remove(listener);
        }

        public void RegisterGeneralListener(Action<object[]> listener,
            bool allowDuplicate = false)
        {
            AddGeneralListener(listener, allowDuplicate);
        }

        public void UnregisterGeneralListener(Action<object[]> listener)
        {
            RemoveGeneralListener(listener);
        }

        public void AddGeneralListener(Action<object[]> listener,
            bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListenersObjects.Contains(listener))
            {
                actionListenersObjects.Insert(0, listener);
            }
        }

        public void RemoveGeneralListener(Action<object[]> listener)
        {
            actionListenersObjects.Remove(listener);
        }

        protected virtual void OnInvoke(params object[] args)
        {
            eventTriggered = true;
            for (int i = generalGameEventListeners.Count - 1; i >= 0; i--)
            {
                if (generalGameEventListeners[i]) generalGameEventListeners[i].OnEventRaised(args);
            }

            for (int i = generalListenerActions.Count - 1; i >= 0; i--)
            {
                generalListenerActions[i].listener.Invoke(generalListenerActions[i], args);
            }

            for (int i = actionListenersObjects.Count - 1; i >= 0; i--)
            {
                actionListenersObjects[i].Invoke(args);
            }
        }
        protected virtual void OnInvoke()
        {
            throw new ArgumentException("Not implemented");
        }

        public void InvokeGeneric(params object[] values)
        {
            OnInvoke(values);
        }
    }

    public class GeneralListenerAction
    {
        public Action<GeneralListenerAction, object[]> listener;
    }
}
