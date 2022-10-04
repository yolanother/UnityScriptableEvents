using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DoubTech.ScriptableEvents
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "DoubTech/Game Events/Game Event")]
    public class GameEvent : TypedBaseGameEvent<UnityEvent, IGameEventListener, Action>
    {
        protected override int RequiredArgCount => 0;

        public void Invoke() => InvokeGeneric();
    }
}
