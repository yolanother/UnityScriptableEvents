using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2, T3, T4> : BaseGameEvent
    {
        private List<IGameEventListener<T1, T2, T3, T4>> listeners = new List<IGameEventListener<T1, T2, T3, T4>>();
        private List<Action<T1, T2, T3, T4>> actionListeners = new List<Action<T1, T2, T3, T4>>();

        public void Invoke(T1 a, T2 b, T3 c, T4 d)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(a, b, c, d);
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                actionListeners[i].Invoke(a, b, c, d);
            }
        }

        protected override void OnInvoke(object a, object b, object c, object d)
        {
            Invoke((T1) a, (T2) b, (T3) c, (T4) d);
        }

        public void RegisterListener(IGameEventListener<T1, T2, T3, T4> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(IGameEventListener<T1, T2, T3, T4> listener)
        {
            listeners.Remove(listener);
        }

        public void AddListener(Action<T1, T2, T3, T4> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
            }
        }

        public void RemoveListener(Action<T1, T2, T3, T4> listener)
        {
            actionListeners.Remove(listener);
        }
    }
}
