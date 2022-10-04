using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2, T3> : TypedBaseGameEvent<
        UnityEvent<T1, T2, T3>,
        IGameEventListener<T1, T2, T3>,
        Action<T1, T2, T3>>
    {
        protected override int RequiredArgCount => 3;

        public void Invoke(T1 a, T2 b, T3 c)
        {
            InvokeGeneric(a, b, c);
        }
    }
}
