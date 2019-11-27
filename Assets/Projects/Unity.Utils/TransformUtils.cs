using UnityEngine;

namespace Unity.Utils {
    public static class TransformUtils {
        public static Transform SetScaleY(this Transform tr, float y) {
            var localScale = tr.localScale;
            localScale = new Vector3(localScale.x, y, localScale.z);
            tr.localScale = localScale;
            return tr;
        }

        public static Transform ResetLocalPosition(this Transform tr) {
            tr.localPosition = Vector3.zero;
            return tr;
        }
    }
}
