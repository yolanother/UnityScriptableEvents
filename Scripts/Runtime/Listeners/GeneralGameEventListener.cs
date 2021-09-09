using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class GeneralGameEventListener : MonoBehaviour
    {
        public BaseGameEvent GameEvent;
        public GeneralUnityEvent OnEvent;

        protected virtual void OnEnable()
        {
            GameEvent.RegisterGeneralListener(this);
        }

        protected virtual void OnDisable()
        {
            GameEvent.UnregisterGeneralListener(this);
        }

        public virtual void Invoke(object[] args)
        {
            GameEvent.Invoke(args);
        }

        public virtual void OnEventRaised(object[] args)
        {
            OnEvent?.Invoke(args);
        }
    }

    [Serializable]
    public class GeneralUnityEvent : UnityEvent<object[]>
    {
    }
}
