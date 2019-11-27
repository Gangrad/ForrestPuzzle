using UnityEngine;

namespace Unity.Utils {
    public static class ColorUtils {
        public static Color ChangeAlpha(this Color color, float newAlpha) {
            return new Color(color.r, color.g, color.b, newAlpha);
        }
    }
}