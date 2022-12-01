using System.Linq;
using System.Reflection;
using UnityEngine;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class EventReceiverMonoBehaviour : MonoBehaviour
    {
        private EventReceiver[] _eventReceivers;

        protected virtual void Awake()
        {
            // Get methods with EventHandler attribute
            _eventReceivers = GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.GetCustomAttributes(typeof(EventHandler), true).Length > 0)
                .Select(a => new EventReceiver(this, a)).ToArray();

            foreach (var eventReceiver in _eventReceivers)
            {
                Debug.Log($"Registered to listen for {eventReceiver.field.Name} with {eventReceiver.method.Name}");
            }
        }
        
        protected virtual void OnEnable()
        {
            foreach (var receiver in _eventReceivers)
            {
                receiver.Register();
            }
        }

        protected  virtual void OnDisable()
        {
            foreach (var receiver in _eventReceivers)
            {
                receiver.Unregister();
            }
        }
    }
}