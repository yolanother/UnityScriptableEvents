﻿using System;
using System.Collections.Generic;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class BaseGameEvent : ScriptableObject
    {
        protected List<GeneralGameEventListener> generalGameEventListeners = new List<GeneralGameEventListener>();
        protected List<GeneralListenerAction> generalListenerActions = new List<GeneralListenerAction>();
        protected List<Action<object[]>> actionListenersObjects = new List<Action<object[]>>();

        public void AddGeneralListener(GeneralListenerAction action, bool allowDuplicate = false)
        {
            if (allowDuplicate || !generalListenerActions.Contains(action))
            {
                generalListenerActions.Insert(0, action);
            }
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

        protected virtual void OnInvoked(object[] args)
        {
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

        protected virtual void OnInvoke(object a)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b, object c)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b, object c, object d)
        {
            throw new ArgumentException("Not implemented");
        }

        public void Invoke(object[] args)
        {
            if (args.Length == 0) Invoke();
            if (args.Length == 1) Invoke(args[0]);
            if (args.Length == 2) Invoke(args[0], args[1]);
            if (args.Length == 3) Invoke(args[0], args[1], args[2]);
            if (args.Length == 4) Invoke(args[0], args[1], args[2], args[3]);
        }

        public void Invoke()
        {
            OnInvoked(new object[0]);
            OnInvoke();
        }

        public void Invoke(object a)
        {
            OnInvoked(new object[] { a });
            OnInvoke(a);
        }

        public void Invoke(object a, object b)
        {
            OnInvoked(new object[] {a, b});
            OnInvoke(a, b);
        }

        public void Invoke(object a, object b, object c)
        {
            OnInvoked(new object[] { a, b, c });
            OnInvoke(a, b, c);
        }

        public void Invoke(object a, object b, object c, object d)
        {
            OnInvoked(new object[] {a, b, c, d});
            OnInvoke(a, b, c, d);
        }
    }

    public class GeneralListenerAction
    {
        public Action<GeneralListenerAction, object[]> listener;
    }
}
