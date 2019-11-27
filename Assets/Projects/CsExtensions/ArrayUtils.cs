namespace CsExtensions {
    public static class ArrayUtils {
        public static void Fill<T>(this T[] array, T obj) {
            for (var i = 0; i < array.Length; ++i)
                array[i] = obj;
        }

        public static T[] Subarray<T>(this T[] array, int from, int size) {
            T[] result = new T[size];
            for (var i = 0; i < size; ++i)
                result[i] = array[i + from];
            return result;
        }
    }
}