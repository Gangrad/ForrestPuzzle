using System;
using System.Globalization;

namespace CsExtensions {
    public static class EnumUtils {
        public static string AsString<T>(T value) where T : struct, IConvertible {
            return value.ToString(CultureInfo.InvariantCulture); // todo
        }

        public static T[] GetValues<T>() where T : struct, IConvertible {
            var arr = Enum.GetValues(typeof(T));
            var res = new T[arr.Length];
            var i = 0;
            foreach (var item in arr) 
                res[i++] = (T) item;
            return res;
        }
    }
}