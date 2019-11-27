using UnityEngine;

namespace Unity.Utils {
    public static class GameObjectUtils {
        public static GameObject SetParent(this GameObject obj, Transform parent) {
            obj.transform.SetParent(parent);
            return obj;
        }
        
        public static GameObject SetLayer(this GameObject obj, string layer) {
            obj.layer = LayerMask.NameToLayer(layer);
            return obj;
        }

        public static bool HasLayer(this GameObject obj, string layer) {
            return obj.layer == LayerMask.NameToLayer(layer);
        }

        public static RectTransform AddDefaultRectTransform(this GameObject obj) {
            return obj.AddComponent<RectTransform>().SetDefault().ResetLocalPosition();
        }
    }
}