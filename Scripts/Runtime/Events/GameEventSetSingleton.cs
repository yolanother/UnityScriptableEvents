using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace DoubTech.ScriptableEvents
{
    public class GameEventSetSingleton<T> : GameEventSet where T : GameEventSet
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (null == instance)
                {
                    T[] results = Resources.FindObjectsOfTypeAll<T>();
                    if (results.Length == 0)
                    {
                        Debug.LogErrorFormat("[ScriptableSingleton] No instance of {0} found.",
                            typeof(T).ToString());
                    }
                    else if (results.Length > 1)
                    {
                        instance = results[0];
                        Debug.LogErrorFormat(
                            "[ScriptableSingleton] Multiple instances of {0} were found. Using {1}",
                            typeof(T).ToString(), instance);
                        instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    }
                    else
                    {
                        instance = results[0];
                        instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
                    }
                }

                return instance;
            }
        }
    }
}
