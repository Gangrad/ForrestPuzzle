using UnityEngine;
using UnityEngine.UI;

namespace Unity.Utils {
    public static class ObjectExtensions {
        public static GameObject GameObject(this Object obj) {
            var go = obj as GameObject;
            if (go != null)
                return go;
            var comp = obj as Component;
            if (comp != null)
                return comp.gameObject;
            return null;
        }

        public static T Component<T>(this Object obj) where T : class {
            var comp = obj as T;
            if (comp != null)
                return comp;
            var go = obj.GameObject();
            return go.GetComponent<T>();
        }

        public static Transform Transform(this Object obj) {
            var go = obj.GameObject();
            return go != null ? go.transform : null;
        }

        public static RectTransform RectTransform(this Object obj) {
            var tr = obj.Transform();
            return tr as RectTransform;
        }

        public static void SetLabelText(this GameObject obj, string text) {
            if (obj == null)
                return;
            var label = obj.GetComponentInChildren<Text>();
            if (label != null)
                label.text = text;
        }

        public static string FullName(this GameObject obj, string separator = ".") {
            return obj.transform.FullName(separator);
        }

        public static void Disable(this GameObject obj) {
            obj.SetActive(false);
        }

        public static void Enable(this GameObject obj) {
            obj.SetActive(true);
        }
    }
}
