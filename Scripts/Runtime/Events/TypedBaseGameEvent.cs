using System;
using System.Collections.Generic;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public abstract class TypedBaseGameEvent<GLOBAL_LISTENER, TYPED_GAME_EVENT_LISTENER, ACTION_LISTENER> : BaseGameEvent where GLOBAL_LISTENER : UnityEventBase, new()
    {
        [Header("Global Unity Events")]
        [Tooltip(
            "These should only be used to trigger things that do not have a level context for example another GameEvent")]
        [SerializeField] private GLOBAL_LISTENER globalListeners = new GLOBAL_LISTENER();
        
        private List<TYPED_GAME_EVENT_LISTENER> listeners = new List<TYPED_GAME_EVENT_LISTENER>();
        private List<ACTION_LISTENER> actionListeners = new List<ACTION_LISTENER>();

        protected abstract int RequiredArgCount { get; }
        
        #if ODIN_INSPECTOR
        [Header("Debug")]
        [ReadOnly]
        [ShowInInspector]
        #endif
        private object[] last;
        
        public override void ClearData()
        {
            base.ClearData();
            last = null;
        }
        
        protected override void OnInvoke(params object[] args)
        {
            if (args.Length != RequiredArgCount)
            {
                throw new ArgumentException($"GameEvent requires {RequiredArgCount} arguments. Received: {args}");
            }
            last = args;
            
            base.OnInvoke(args);

            var invoke = typeof(ACTION_LISTENER).GetMethod("Invoke");
            var onEventRaised = typeof(TYPED_GAME_EVENT_LISTENER).GetMethod("OnEventRaised");
            var giInvoke = typeof(GLOBAL_LISTENER).GetMethod("Invoke");
            
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                onEventRaised.Invoke(listeners[i], args);
            }

            for (int i = actionListeners.Count - 1; i >= 0; i--)
            {
                invoke.Invoke(actionListeners[i], args);
            }
            
            giInvoke.Invoke(globalListeners, args);
        }

        public void RegisterListener(TYPED_GAME_EVENT_LISTENER listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !listeners.Contains(listener))
            {
                listeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered && last != null)
                {
                    var onEventRaised = typeof(TYPED_GAME_EVENT_LISTENER).GetMethod("OnEventRaised");
                    onEventRaised.Invoke(listener, last);
                }
            }
        }

        protected override void OnReInvokeGeneric(GeneralGameEventListener listener)
        {
            listener.Invoke(last);
        }

        protected override void OnReInvokeGeneric(GeneralListenerAction action)
        {
            action.listener.Invoke(action, last);
        }

        public void UnregisterListener(TYPED_GAME_EVENT_LISTENER listener)
        {
            listeners.Remove(listener);
        }

        public void AddListener(ACTION_LISTENER listener, bool allowDuplicate = false)
        {
            if (allowDuplicate || !actionListeners.Contains(listener))
            {
                actionListeners.Insert(0, listener);
                if (reusePastEvent && eventTriggered)
                {
                    var invoke = typeof(ACTION_LISTENER).GetMethod("Invoke");
                    invoke.Invoke(listener, last);
                }
            }
        }

        public void RemoveListener(ACTION_LISTENER listener)
        {
            actionListeners.Remove(listener);
        }
    }
}
