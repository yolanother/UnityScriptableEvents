using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEventListenerT<T> : MonoBehaviour
    {
        [SerializeField] private GameEventT<T> gameEvent;
        [SerializeField] private UnityEvent<T> response = new UnityEvent<T>();

        public UnityEvent<T> OnEvent => response;

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.RegisterListener(this);
        }

        public void OnEventRaised(T t)
        {
            response?.Invoke(t);
        }

        public void Invoke(T t)
        {
            gameEvent.Invoke(t);
        }
    }
}
