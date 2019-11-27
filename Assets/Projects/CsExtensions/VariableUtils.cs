namespace CsExtensions {
    public class VariableUtils {
        public static void Swap<T>(ref T v1, ref T v2) {
            var tmp = v1;
            v1 = v2;
            v2 = tmp;
        }
    }
}