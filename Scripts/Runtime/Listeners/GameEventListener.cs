using System;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    [Serializable]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent gameEvent;
        [SerializeField] private UnityEvent response = new UnityEvent();

        public UnityEvent OnEvent => response;

        private void OnEnable()
        {
            if (null == gameEvent)
                throw new ArgumentException(name + " does not hav a game event set.");
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.RegisterListener(this);
        }

        public void OnEventRaised()
        {
            response?.Invoke();
        }

        public void Invoke()
        {
            gameEvent.Invoke();
        }
    }
}
