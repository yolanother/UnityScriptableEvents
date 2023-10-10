using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class ThreeStringGameEventListener : GameEventListener<string, string, string, ThreeStringGameEvent, ThreeStringUnityEvent>
    {
        [SerializeField] private ThreeStringGameEvent gameEvent;
        [SerializeField] private ThreeStringUnityEvent onEvent = new ThreeStringUnityEvent();
        [SerializeField] private FormattedStringEvent[] formattedStringEvents;

        public override ThreeStringGameEvent GameEvent => gameEvent;
        public override ThreeStringUnityEvent OnEvent => onEvent;

        public override void OnEventRaised(string t1, string t2, string t3)
        {
            base.OnEventRaised(t1, t2, t3);
            for (int i = 0; i < formattedStringEvents.Length; i++)
            {
                try
                {
                    formattedStringEvents[i].Invoke(new string[] {t1, t2, t3});
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }

    [Serializable]
    public class ThreeStringUnityEvent : UnityEvent<string, string, string>
    {
    }
}
