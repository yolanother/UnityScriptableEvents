using System;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class BaseGameEvent : ScriptableObject
    {
        protected virtual void OnInvoke()
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b, object c)
        {
            throw new ArgumentException("Not implemented");
        }

        protected virtual void OnInvoke(object a, object b, object c, object d)
        {
            throw new ArgumentException("Not implemented");
        }

        public void Invoke()
        {
            OnInvoke();
        }

        public void Invoke(object a)
        {
            OnInvoke(a);
        }

        public void Invoke(object a, object b)
        {
            OnInvoke(a, b);
        }

        public void Invoke(object a, object b, object c)
        {
            OnInvoke(a, b, c);
        }

        public void Invoke(object a, object b, object c, object d)
        {
            OnInvoke(a, b, c, d);
        }
    }
}
