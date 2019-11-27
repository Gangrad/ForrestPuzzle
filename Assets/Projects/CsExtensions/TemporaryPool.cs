using System;
using System.Collections.Generic;

namespace CsExtensions {
    // todo: fix bug with double using of temp objects at the same time
    public static class TemporaryPool {
        private static Dictionary<Type, object> _tempObjs;
        
        public static T[] EmptyArray<T>() {
            return Temp(() => new T[0]);
        }

        public static List<T> EmptyList<T>() {
            var list = Temp(() => new List<T>());
            list.Clear();
            return list;
        }

        public static HashSet<T> EmptyHashSet<T>() {
            var hs = Temp(() => new HashSet<T>());
            hs.Clear();
            return hs;
        }

        private static T Temp<T>(Func<T> create) {
            if (_tempObjs == null)
                _tempObjs = new Dictionary<Type, object>();
            var type = typeof(T);
            object o;
            if (_tempObjs.TryGetValue(type, out o))
                return (T) o;
            var obj = create();
            _tempObjs[type] = obj;
            return obj;
        }
    }
}