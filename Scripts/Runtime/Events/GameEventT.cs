using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T> : BaseGameEvent
    {
        [Tooltip(
            "If an event has already been received store the data for that event and when a new register/add is called immediately return that value")]
        [SerializeField]
        private bool reusePastEvent;

        [Header("Debugging")]
        [SerializeField] private bool debugInvoke;
        private List<IGameEventListenerT<T>> listeners = new List<IGameEventListenerT<T>>();
        private List<Action<T>> actionListeners = new List<Action<T>>();

        private T last;
        private bool eventTriggered;

        public virtual void Invoke(T a)
        {
            if (reusePastEvent)
            {
                last = a;
                eventTriggered = true;
            }

            if (debugInvoke)
            {
                Debug.Log("Invoking " + name);
            }

            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(a);
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                actionListeners[i].Invoke(a);
            }
        }

        protected override void OnInvoke(object a)
        {
            Invoke((T) a);
        }

        public virtual void AddListener(Action<T> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    listener.Invoke(last);
                }
            }
        }

        public void RegisterListener(Action<T> listener, bool allowDuplicate = false)
        {
            AddListener(listener, allowDuplicate);
        }

        public void UnregisterListener(Action<T> listener)
        {
            RemoveListener(listener);
        }

        public virtual void RemoveListener(Action<T> listener)
        {
            actionListeners.Remove(listener);
        }

        public void RegisterListener(IGameEventListenerT<T> listener, bool allowDuplicate = false)
        {
            AddListener(listener, allowDuplicate);
        }

        public void UnregisterListener(IGameEventListenerT<T> listener)
        {
            RemoveListener(listener);
        }

        public virtual void AddListener(IGameEventListenerT<T> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    listener.OnEventRaised(last);
                }
            }
        }

        public virtual void RemoveListener(IGameEventListenerT<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
