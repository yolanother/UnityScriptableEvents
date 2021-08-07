using System;
using System.Collections.Generic;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    [CreateAssetMenu(fileName="GameEvent", menuName="DoubTech/Game Events/Game Event")]
    [Serializable]
    public class GameEvent : BaseGameEvent
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();
        private List<Action> actionListeners = new List<Action>();

        protected override void OnInvoke()
        {
            Debug.Log("Invoke: " + name);
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                if(listeners[i]) listeners[i].OnEventRaised();
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                actionListeners[i].Invoke();
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

        public void AddListener(Action listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
            }
        }

        public void RemoveListener(Action listener)
        {
            actionListeners.Remove(listener);
        }

        public void RegisterListener(GameEventListener listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
