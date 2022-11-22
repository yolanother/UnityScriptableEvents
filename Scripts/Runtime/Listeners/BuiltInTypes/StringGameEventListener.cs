using System;
using System.Text.RegularExpressions;
using DoubTech.ScriptableEvents.BuiltinTypes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.Listeners.BuiltInTypes
{
    [Serializable]
    public class StringGameEventListener : GameEventListener<string, StringGameEvent, StringUnityEvent>
    {
        [SerializeField] private StringGameEvent gameEvent;
        [SerializeField] private StringUnityEvent onEvent = new StringUnityEvent();
        [SerializeField] private FormattedStringEvent[] formattedStringEvents;

        public override StringGameEvent GameEvent => gameEvent;
        public override StringUnityEvent OnEvent => onEvent;

        public override void OnEventRaised(string t)
        {
            base.OnEventRaised(t);
            for (int i = 0; i < formattedStringEvents.Length; i++)
            {
                try
                {
                    formattedStringEvents[i].Invoke(t);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
    }

    [Serializable]
    public class StringUnityEvent : UnityEvent<string>
    {
    }

    [Serializable]
    public class FormattedStringEvent
    {
        public string format;
        public bool requireTextForFormat;
        public StringUnityEvent onEvent = new StringUnityEvent();

        public void Invoke(params string[] text)
        {
            var format = this.format;
            if (null != text && text.Length > 0)
            {
                bool hasText = false;
                format = format.Replace("{value}", text[0]);
                for (int i = 0; i < text.Length; i++)
                {
                    format = format.Replace("{" + i + "}", text[i]);
                    if (!string.IsNullOrEmpty(text[i])) hasText = true;
                }

                if (requireTextForFormat && !hasText) format = "";
            }
            else
            {
                format = Regex.Replace(format, @"\{([0-9]+|value)\}", "");
            }

            onEvent?.Invoke(format);
        }
    }
}
