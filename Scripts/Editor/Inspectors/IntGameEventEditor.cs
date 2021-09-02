using UnityEditor;
using UnityEngine;

namespace DoubTech.ScriptableEvents.BuiltinTypes
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntGameEventEditor : Editor
    {
        private int value;

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            var intEvent = target as IntGameEvent;
            value = EditorGUILayout.IntField("Value", value);
            if(GUILayout.Button("Invoke", GUILayout.Width(75))) intEvent.Invoke(value);
            GUILayout.EndHorizontal();
        }
    }
}
