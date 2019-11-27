using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    public abstract class PropertyDrawerBase : PropertyDrawer {
        protected virtual int PropertyHeight {
            get { return 16; }
        }

        protected bool Foldout;
        protected abstract int PropertiesNum { get; }

        protected abstract void DrawProperty(SerializedProperty property);

        protected void DrawDefaultStringProperty(SerializedProperty property, string fieldName) {
            var sProp = property.FindPropertyRelative(fieldName);
            sProp.stringValue = EditorGUILayout.TextField(fieldName, sProp.stringValue);
        }

        protected void DrawDefaultObjectProperty(SerializedProperty property, string fieldName) {
            var objProp = property.FindPropertyRelative(fieldName);
            EditorGUILayout.ObjectField(objProp, new GUIContent(fieldName));
        }

        protected void DrawDefaultVector3Property(SerializedProperty property, string fieldName) {
            var vProp = property.FindPropertyRelative(fieldName);
            vProp.vector3Value = EditorGUILayout.Vector3Field(fieldName, vProp.vector3Value);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            Foldout = EditorGUI.Foldout(position, Foldout, label);
            if (Foldout) {
                EditorGUI.indentLevel++;
                DrawProperty(property);
                EditorGUI.indentLevel--;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return PropertyHeight;
        }
    }
}
