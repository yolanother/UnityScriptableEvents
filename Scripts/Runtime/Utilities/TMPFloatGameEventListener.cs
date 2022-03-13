using System;
using DoubTech.ScriptableEvents.BuiltinTypes;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DoubTech.ScriptableEvents.Utilities
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPFloatGameEventListener : MonoBehaviour
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
                if (!string.IsNullOrEmpty(stringFormat)) text = string.Format(stringFormat, value.ToString(numberFormat));
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
