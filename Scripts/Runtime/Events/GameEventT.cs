using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class GameEventT<T> : ScriptableObject
    {
        private List<IGameEventListenerT<T>> listeners = new List<IGameEventListenerT<T>>();
        private List<Action<T>> actionListeners = new List<Action<T>>();

        public void Invoke(T a)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(a);
            }
        }

        public void AddListener(Action<T> listener, bool allowDuplicate = false)
        {
            RegisterListener(listener, allowDuplicate);
        }

        public void RegisterListener(Action<T> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(Action<T> listener)
        {
            actionListeners.Remove(listener);
        }

        public void RemoveListener(Action<T> listener)
        {
            UnregisterListener(listener);
        }

        public void RegisterListener(IGameEventListenerT<T> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(IGameEventListenerT<T> listener)
        {
            listeners.Remove(listener);
        }

        public void AddListener(IGameEventListenerT<T> listener, bool allowDuplicate = false)
        {
            RegisterListener(listener, allowDuplicate);
        }

        public void RemoveListener(IGameEventListenerT<T> listener)
        {
            UnregisterListener(listener);
        }
    }
}
