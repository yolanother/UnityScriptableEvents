using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent : BaseGameEvent
    {
        [Header("Configuration")]
        [Tooltip(
            "If an event has already been received store the data for that event and when a new register/add is called immediately return that value")]
        [SerializeField]
        private bool reusePastEvent;

        [Header("Global Unity Events")]
        [Tooltip(
            "These should only be used to trigger things that do not have a level context for example another GameEvent")]
        [SerializeField] private UnityEvent globalListeners = new UnityEvent();

        [Header("Debugging")]
        [SerializeField] private bool debugInvoke;
        private List<IGameEventListener> listeners = new List<IGameEventListener>();
        private List<Action> actionListeners = new List<Action>();

        private bool eventTriggered;

        public virtual void Invoke()
        {
            if (reusePastEvent)
            {
                eventTriggered = true;
            }

            if (debugInvoke)
            {
                Debug.Log("Invoking " + name);
            }

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                actionListeners[i].Invoke();
            }
            
            globalListeners.Invoke();
        }

        protected override void OnInvoke()
        {
            Invoke();
        }

        public virtual void AddListener(Action listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    listener.Invoke();
                }
            }
        }

        public void RegisterListener(Action listener, bool allowDuplicate = false)
        {
            AddListener(listener, allowDuplicate);
        }

        public void UnregisterListener(Action listener)
        {
            RemoveListener(listener);
        }

        public virtual void RemoveListener(Action listener)
        {
            actionListeners.Remove(listener);
        }

        public void RegisterListener(IGameEventListener listener, bool allowDuplicate = false)
        {
            AddListener(listener, allowDuplicate);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            RemoveListener(listener);
        }

        public virtual void AddListener(IGameEventListener listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    listener.OnEventRaised();
                }
            }
        }

        public virtual void RemoveListener(IGameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
