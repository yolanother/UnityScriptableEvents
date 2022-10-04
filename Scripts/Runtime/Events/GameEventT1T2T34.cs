using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    public class GameEvent<T1, T2, T3, T4> : TypedBaseGameEvent<
        UnityEvent<T1, T2, T3, T4>,
        IGameEventListener<T1, T2, T3, T4>,
        Action<T1, T2, T3, T4>>
    {
        protected override int RequiredArgCount => 4;

        public void Invoke(T1 a, T2 b, T3 c, T4 d)
        {
            InvokeGeneric(a, b, c, d);
        }
    }
}