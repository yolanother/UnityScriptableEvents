using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class TwoStringGameEventListener : GameEventListener<string, string, TwoStringGameEvent, TwoStringUnityEvent>
    {
        [SerializeField] private TwoStringGameEvent gameEvent;
        [SerializeField] private TwoStringUnityEvent onEvent = new TwoStringUnityEvent();
        [SerializeField] private FormattedStringEvent[] formattedStringEvents;

        public override TwoStringGameEvent GameEvent => gameEvent;
        public override TwoStringUnityEvent OnEvent => onEvent;

        public override void OnEventRaised(string t1, string t2)
        {
            base.OnEventRaised(t1, t2);
            for (int i = 0; i < formattedStringEvents.Length; i++)
            {
                try
                {
                    formattedStringEvents[i].Invoke(new string[] {t1, t2});
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }

    [Serializable]
    public class TwoStringUnityEvent : UnityEvent<string, string>
    {
    }
}