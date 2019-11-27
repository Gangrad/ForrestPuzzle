using UnityEngine;

namespace Unity.Utils {
    public static class RectTransformUtils {
        public static RectTransform SetPivot(this RectTransform rt, float x, float y) {
            rt.pivot = new Vector2(x, y);
            return rt;
        }

        public static RectTransform SetAnchors(this RectTransform rt, float x, float y) {
            rt.anchorMin = new Vector2(x, y);
            rt.anchorMax = new Vector2(x, y);
            return rt;
        }

        public static float GetHeight(this RectTransform rt) {
            // todo
            return rt.rect.height;
        }
        
        public static void SetHeight(this RectTransform rt, float h) {
            //var c = (rt.offsetMin.x + rt.offsetMax.x)/2;
            // todo
            rt.offsetMax = new Vector2(rt.offsetMax.x, h/2);
            rt.offsetMin = new Vector2(rt.offsetMin.x, -h/2);
        }

        public static float GetWidth(this RectTransform rt) {
            // todo
            return rt.rect.width;
        }

        public static RectTransform SetWidth(this RectTransform rt, float w) {
            // todo
            rt.offsetMax = new Vector2(w/2, rt.offsetMax.y);
            rt.offsetMin = new Vector2(-w/2, rt.offsetMin.y);
            return rt;
        }

        public static RectTransform SetRect(this RectTransform rt, float w, float h) {
            // todo
            rt.offsetMax = new Vector2(w/2, h/2);
            rt.offsetMin = new Vector2(-w/2, -h/2);
            return rt;
        }

        //----------------------

        public static RectTransform SetPivotY(this RectTransform rt, float y) {
            //rt.pivot = new Vector2(rt.pivot.x, y);
            rt.SetPivot(rt.pivot.x, y);
            return rt;
        }

        public static RectTransform SetAnchorsY(this RectTransform rt, float y) {
            rt.anchorMin = new Vector2(rt.anchorMin.x, y);
            rt.anchorMax = new Vector2(rt.anchorMax.x, y);
            return rt;
        }

        //--------------------------

        public static RectTransform SetPivotAndAnchorsToTop(this RectTransform rt) {
            rt.SetPivotY(1);
            rt.SetAnchorsY(1);
            return rt;
        }

        public static RectTransform SetPivotAndAnchorsToTopLeft(this RectTransform rt) {
            rt.SetPivot(0, 1);
            rt.SetAnchors(0, 1);
            return rt;
        }

        public static RectTransform SetPivotAndAnchorsToBottom(this RectTransform rt) {
            rt.SetPivotY(0);
            rt.SetAnchorsY(0);
            return rt;
        }

        public static RectTransform SetPivotAndAnchorsToBottomLeft(this RectTransform rt) {
            rt.SetPivot(0, 0);
            rt.SetAnchors(0, 0);
            return rt;
        }

        //-------------------------

        public static RectTransform SetDefault(this RectTransform rt) {
            rt.anchorMin = Vector2.zero;
            rt.anchorMax = Vector2.one;
            rt.offsetMin = rt.offsetMax = Vector2.zero;
            rt.pivot = new Vector2(.5f, .5f);
            return rt;
        }

        public static RectTransform ResetLocalPosition(this RectTransform rt) {
            return (RectTransform) ((Transform) rt).ResetLocalPosition();
        }
    }
}
