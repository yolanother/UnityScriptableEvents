using System;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1> : TypedBaseGameEvent<
        UnityEvent<T1>,
        IGameEventListener<T1>,
        Action<T1>>
    {
        protected override int RequiredArgCount => 1;

        public virtual void Invoke(T1 a)
        {
            InvokeGeneric(a);
        }
    }
}
