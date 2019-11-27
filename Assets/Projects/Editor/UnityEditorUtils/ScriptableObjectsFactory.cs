using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    public class ScriptableObjectsFactory : EditorWindow {
        private Type[] _scriptableObjectTypes;
        
        [MenuItem("Tools/ScriptableObjectsFactory")]
        public static void ShowWindow() {
            GetWindow(typeof(ScriptableObjectsFactory));
        }

        private void OnGUI () {
            if (_scriptableObjectTypes == null) {
                var seeker = new ScriptableObjectSeeker();
                _scriptableObjectTypes = seeker.GetScriptableObjectTypes();
            }
            AddButtonsForTypes(_scriptableObjectTypes);
        }

        private static void AddButtonsForTypes(IEnumerable<Type> types) {
            foreach (var type in types) 
                AddButton(type);
        }

        private static void AddButton(Type type) {
            var labelText = type.Name;
            if (GUILayout.Button(labelText))
                ScriptableObjectUtils.CreateAsset(type);
        }
    }
}