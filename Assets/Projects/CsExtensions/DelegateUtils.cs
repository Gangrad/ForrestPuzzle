using System;

namespace CsExtensions {
    public static class DelegateUtils {
        public static void SafeInvoke(this Action action) {
            if (action != null)
                action();
        }

        public static void SafeInvoke<T>(this Action<T> action, T arg) {
            if (action != null)
                action(arg);
        }

        public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 arg1, T2 arg2) {
            if (action != null)
                action(arg1, arg2);
        }

        public static Action MergeWith(this Action action1, Action action2) {
            return () => {
                action1();
                action2();
            };
        }
    }
}