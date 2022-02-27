using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DoubTech.ScriptableEvents.Utilities
{
    [RequireComponent(typeof(Text))]
    public class TextViewIntGameEventListener : MonoBehaviour
    {
        [Header("String Format")]
        [SerializeField] private string numberFormat;
        [SerializeField] private string stringFormat;

        [Header("Component Mapping")]
        [SerializeField] private IntGameEvent intGameEvent;
        [SerializeField] private Text textView;

        private void OnValidate()
        {
            if (!textView) textView = GetComponent<Text>();
        }

        private void Start()
        {
            if (!textView) textView = GetComponent<Text>();
            intGameEvent.AddListener(SetValue);
        }

        private void OnDestroy()
        {
            intGameEvent.RemoveListener(SetValue);
        }

        public void SetValue(int value)
        {
            string text;
            if (!string.IsNullOrEmpty(numberFormat))
            {
                if (null != stringFormat) text = string.Format(stringFormat, value.ToString(numberFormat));
                else text = value.ToString(numberFormat);
            }
            else
            {
                if (!string.IsNullOrEmpty(stringFormat)) text = string.Format(stringFormat, value);
                else text = value.ToString();
            }

            textView.text = text;
        }

        [Serializable] public class ValueChangedEvent : UnityEvent<string> {}
    }
}
