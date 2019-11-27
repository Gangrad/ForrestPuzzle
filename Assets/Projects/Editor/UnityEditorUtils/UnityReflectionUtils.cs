using CsExtensions;
using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    public static class UnityReflectionUtils {
        public static T GetValue<T>(this SerializedProperty property) where T : class {
            var targetObject = property.serializedObject.targetObject;
            return targetObject.GetFieldValue<T>(property.name);
        }

        public static GameObject GameObject(this SerializedProperty property) {
            var comp = (Component) property.serializedObject.targetObject;
            return comp.gameObject;
        }
    }
}