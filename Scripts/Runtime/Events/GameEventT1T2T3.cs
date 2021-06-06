using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2, T3> : ScriptableObject
    {
        private List<GameEventListener<T1, T2, T3>> listeners = new List<GameEventListener<T1, T2, T3>>();

        public void Raise(T1 a, T2 b, T3 c)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(a, b, c);
            }
        }

        public void RegisterListener(GameEventListener<T1, T2, T3> listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(GameEventListener<T1, T2, T3> listener)
        {
            listeners.Remove(listener);
        }
    }

    public class GameEventListener<T1, T2, T3> : MonoBehaviour
    {
        [SerializeField] private GameEvent<T1, T2, T3> gameEvent;
        [SerializeField] private UnityEvent<T1, T2, T3> response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.RegisterListener(this);
        }

        public void OnEventRaised(T1 a, T2 b, T3 c)
        {
            response?.Invoke(a, b, c);
        }
    }
}
