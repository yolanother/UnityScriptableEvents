using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public interface ISimpleGameEventValidator
    {
        bool OnValidateEvent();
    }
    
    public interface IGenericGameEventValidator
    {
        bool OnValidateEvent(MonoBehaviour behaviour);
    }
    
    public interface IGameEventValidator
    {
        bool OnValidateEvent(BaseGameEvent gameEvent);
    }
    public interface IGameEventValidator<T>
    {
        bool OnValidateEvent(GameEvent<T> gameEvent);
    }
    public interface IGameEventValidator<T1, T2>
    {
        bool OnValidateEvent(GameEvent<T1, T2> gameEvent);
    }
    public interface IGameEventValidator<T1, T2, T3>
    {
        bool OnValidateEvent(GameEvent<T1, T2, T3> gameEvent);
    }
    public interface IGameEventValidator<T1, T2, T3, T4>
    {
        bool OnValidateEvent(GameEvent<T1, T2, T3, T4> gameEvent);
    }
}
