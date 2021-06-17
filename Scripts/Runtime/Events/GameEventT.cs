using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class GameEventT<T> : BaseGameEvent
    {
        private List<IGameEventListenerT<T>> listeners = new List<IGameEventListenerT<T>>();
        private List<Action<T>> actionListeners = new List<Action<T>>();

        public virtual void Invoke(T a)
        {
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
            }
        }

        public virtual void RemoveListener(IGameEventListenerT<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}
