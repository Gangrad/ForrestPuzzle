namespace CsExtensions {
    public static class ObjectUtils {
        public static bool HasValue<T>(this T value) where T : class {
            return value != null;
        }
    }
}