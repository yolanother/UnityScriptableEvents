using System;

namespace DoubTech.ScriptableEvents.PersistantDataGameEvents
{
    public class PersistantDataGameEventT<T> : GameEventT<T>
    {
        private bool hasData = false;
        private T lastData;

        public void ClearData()
        {
            hasData = false;
            lastData = default(T);
        }

        public override void Invoke(T a)
        {
            base.Invoke(a);
            hasData = true;
            lastData = a;
        }

        public override void AddListener(Action<T> listener, bool allowDuplicate = false)
        {
            base.AddListener(listener, allowDuplicate);
            if (hasData)
            {
                listener.Invoke(lastData);
            }
        }

        public override void AddListener(IGameEventListenerT<T> listener, bool allowDuplicate = false)
        {
            base.AddListener(listener, allowDuplicate);
            if (hasData)
            {
                listener.OnEventRaised(lastData);
            }
        }
    }
}
