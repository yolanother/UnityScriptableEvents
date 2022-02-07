using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public interface IGameEventListenerValidator
    {
        bool OnValidateEventListener(MonoBehaviour sender);
    }
    public interface IGameEventListenerValidator<T>
    {
        bool OnValidateEventListener(MonoBehaviour sender, T a);
    }
    public interface IGameEventListenerValidator<T1, T2>
    {
        bool OnValidateEventListener(MonoBehaviour sender, T1 a, T2 b);
    }
    public interface IGameEventListenerValidator<T1, T2, T3>
    {
        bool OnValidateEventListener(MonoBehaviour sender, T1 a, T2 b, T3 c);
    }
    public interface IGameEventListenerValidator<T1, T2, T3, T4>
    {
        bool OnValidateEventListener(MonoBehaviour sender, T1 a, T2 b, T3 c, T4 d);
    }
}
