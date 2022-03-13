using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Utilities
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPFloatTimespanGameEventListener : MonoBehaviour
    {
        [Header("String Format")]
        [SerializeField] private string numberFormat;
        [SerializeField] private string stringFormat;

        [Header("Component Mapping")]
        [SerializeField] private FloatGameEvent floatGameEvent;
        [SerializeField] private TextMeshProUGUI textView;

        private void OnValidate()
        {
            if (!textView) textView = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (!textView) textView = GetComponent<TextMeshProUGUI>();
            floatGameEvent.AddListener(SetValue);
        }

        private void OnDestroy()
        {
            floatGameEvent.RemoveListener(SetValue);
        }

        public void SetValue(float value)
        {
            string text;
            if (!string.IsNullOrEmpty(numberFormat))
            {
                if (!string.IsNullOrEmpty(stringFormat)) text = string.Format(stringFormat, TimeSpan.FromSeconds(value).ToString(numberFormat));
                else text = TimeSpan.FromSeconds(value).ToString(numberFormat);
            }
            else
            {
                if (!string.IsNullOrEmpty(stringFormat)) text = string.Format(stringFormat, TimeSpan.FromSeconds(value).ToString());
                else text = TimeSpan.FromSeconds(value).ToString();
            }

            textView.text = text;
        }

        [Serializable] public class ValueChangedEvent : UnityEvent<string> {}
    }
}
