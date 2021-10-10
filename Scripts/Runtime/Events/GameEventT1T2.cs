using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2> : BaseGameEvent
    {
        [Header("Debugging")]
        [SerializeField] private bool debugInvoke;
        private List<IGameEventListener<T1, T2>> listeners = new List<IGameEventListener<T1, T2>>();
        private List<Action<T1, T2>> actionListeners = new List<Action<T1, T2>>();

        public virtual void Invoke(T1 a, T2 b)
        {
            if (debugInvoke)
            {
                Debug.Log("Invoking " + name);
            }
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(a, b);
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                actionListeners[i].Invoke(a, b);
            }
        }

        protected override void OnInvoke(object a, object b)
        {
            Invoke((T1) a, (T2) b);
        }

        public void RegisterListener(IGameEventListener<T1, T2> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T1, T2> listener)
        {
            listeners.Remove(listener);
        }

        public void AddListener(Action<T1, T2> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
            }
        }

        public void RemoveListener(Action<T1, T2> listener)
        {
            actionListeners.Remove(listener);
        }
    }
}
