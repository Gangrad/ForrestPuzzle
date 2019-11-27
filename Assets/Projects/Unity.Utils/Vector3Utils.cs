using UnityEngine;

namespace Unity.Utils {
    public static class Vector3Utils {
        public static Vector3 AddX(this Vector3 v, float x) {
            return new Vector3(v.x + x, v.y, v.z);
        }

        public static Vector3 AddY(this Vector3 v, float y) {
            return new Vector3(v.x, v.y + y, v.z);
        }

        public static Vector3 AddZ(this Vector3 v, float z) {
            return new Vector3(v.x, v.y, v.z + z);
        }

        public static Vector3 Add(this Vector3 v, float x, float y, float z) {
            return new Vector3(v.x + x, v.y + y, v.z + z);
        }

        public static bool IsZero(this Vector3 v) {
            return Mathf.Abs(v.x) <= Mathf.Epsilon && 
                   Mathf.Abs(v.y) <= Mathf.Epsilon &&
                   Mathf.Abs(v.z) <= Mathf.Epsilon;
        }

        public static Vector3 XZNormalized(this Vector3 v) {
            v.y = 0;
            return v.normalized;
        }
    }
}
