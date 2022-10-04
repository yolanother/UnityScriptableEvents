using System.Reflection;

namespace DoubTech.ScriptableEvents.Utilities
{
    public class EventReceiver
    {
        public EventReceiver(object parent, MethodInfo method)
        {
            this.parent = parent;
            this.method = method;
            var attribute = method.GetCustomAttribute<EventHandler>(); 
            fieldName = attribute.Field;
            field = parent.GetType().GetField(fieldName, 
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                
            gameEvent = field.GetValue(parent) as BaseGameEvent;
        }

        public readonly MethodInfo method;
        public readonly FieldInfo field;
        private readonly string fieldName;
        private readonly object parent;
        private BaseGameEvent gameEvent;

        public void Register()
        {
            gameEvent.RegisterGeneralListener(OnEvent);
        }

        public void Unregister()
        {
            gameEvent.UnregisterGeneralListener(OnEvent);
        }
            

        private void OnEvent(object[] objs)
        {
            method.Invoke(parent, objs);
        }
    }
}