namespace DoubTech.ScriptableEvents.Integrations.Photon
{
    public class NetworkSyncedEventsSingleton : NetworkSyncedEvents
    {
        private static NetworkSyncedEventsSingleton instance;
        public static NetworkSyncedEventsSingleton Instance => instance;

        public override void OnEnable()
        {
            base.OnEnable();
            instance = this;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (instance == this)
            {
                instance = null;
            }
        }

        public static void PostEvent<T>(GameEvent<T> e, T data)
        {
            ((NetworkSyncedEvents) Instance).PostEvent(e, data);
        }

        public static void PostEvent(GameEvent e)
        {
            ((NetworkSyncedEvents) Instance).PostEvent(e);
        }

        public static void PostEvent(string e)
        {
            ((NetworkSyncedEvents) Instance).PostEvent(e);
        }

        public static void PostEvent(string e, object data)
        {
            ((NetworkSyncedEvents) Instance).PostEvent(e, data);
        }
    }
}
