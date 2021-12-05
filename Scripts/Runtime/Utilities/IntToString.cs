using System;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class IntToString : MonoBehaviour
    {
        [FormerlySerializedAs("format")] [SerializeField]
        private string numberFormat;

        [SerializeField] private string stringFormat;
        [SerializeField] private ValueChangedEvent onValueChanged = new ValueChangedEvent();

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
                if (null != stringFormat) text = string.Format(stringFormat, value);
                else text = value.ToString();
            }

            onValueChanged.Invoke(text);
        }

        [Serializable] public class ValueChangedEvent : UnityEvent<string> {}
    }
}
