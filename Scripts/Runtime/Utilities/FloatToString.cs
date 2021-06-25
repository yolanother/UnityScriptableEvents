using DoubTech.ScriptableEvents.Listeners.BuiltInTypes;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class FloatToString : MonoBehaviour
    {
        [Tooltip("The float format to use. Ex. 0.00 for a two decimal place number")]
        [SerializeField] private string format;
        [SerializeField] private StringUnityEvent onValueChanged = new StringUnityEvent();

        public void SetValue(float value)
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
    }
}
