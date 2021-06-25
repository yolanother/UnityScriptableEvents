using System;
using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class IntToString : MonoBehaviour
    {
        [SerializeField]
        private string format;
        [SerializeField] private ValueChangedEvent onValueChanged = new ValueChangedEvent();

        public void SetValue(int value)
        {
            if (!string.IsNullOrEmpty(format))
            {
                onValueChanged.Invoke(value.ToString(format));
            }
            else
            {
                onValueChanged.Invoke(value.ToString());
            }
        }

        [Serializable] public class ValueChangedEvent : UnityEvent<string> {}
    }
}
