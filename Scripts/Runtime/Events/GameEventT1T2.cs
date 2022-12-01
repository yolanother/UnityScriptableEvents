using System;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2> : TypedBaseGameEvent<
        UnityEvent<T1, T2>,
        IGameEventListener<T1, T2>,
        Action<T1, T2>>
    {
        protected override int RequiredArgCount => 2;
        
        public virtual void Invoke(T1 a, T2 b)
        {
            InvokeGeneric(a, b);
        }
    }
}
