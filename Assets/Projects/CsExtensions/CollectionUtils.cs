using System;
using System.Collections.Generic;

namespace CsExtensions {
    public static class CollectionUtils {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(
            this IEnumerable<KeyValuePair<TKey, TValue>> collection) {
            var res = new Dictionary<TKey, TValue>();
            foreach (var el in collection) {
                res[el.Key] = el.Value;
            }
            return res;
        }

        public static Dictionary<Type, T> ToDictionaryByType<T>(this IEnumerable<T> collection) {
            var res = new Dictionary<Type, T>();
            foreach (var el in collection)
                res[el.GetType()] = el;
            return res;
        }

        public static void Swap<T>(IList<T> list, int i1, int i2) {
            var tmp = list[i1];
            list[i1] = list[i2];
            list[i2] = tmp;
        }

        public static void Copy<T>(IList<T> source, int sourceIndex, IList<T> destination, int destIndex, int length) {
            for (var i = 0; i < length; ++i)
                destination[destIndex + i] = source[sourceIndex + i];
        }

        public static string[] SelectToStringArray<T>(this IEnumerable<T> collection) {
            return collection.SelectToArray(item => item.ToString());
        }
        
        public static TTarget[] SelectToArray<TSource, TTarget>(this IEnumerable<TSource> collection,
            Func<TSource, TTarget> convert) {
            var sources = collection.AsTempList();
            int size = sources.Count;
            var result = new TTarget[size];
            for (var i = 0; i < size; ++i) {
                var source = sources[i];
                var target = convert(source);
                result[i] = target;
            }
            return result;
        }

        public static int Size<T>(this IEnumerable<T> collection) {
            var list = collection as IList<T>;
            if (list != null)
                return list.Count;
            
            var result = 0;
            foreach (var unused in collection)
                result++;
            return result;
        }

        public static T FirstItem<T>(this IEnumerable<T> collection) where T : class {
            foreach (var item in collection)
                return item;
            throw new ArgumentOutOfRangeException();
        }

        public static T FirstItem<T>(this IEnumerable<T> collection, T defaultValue) {
            foreach (var item in collection)
                return item;
            return defaultValue;
        }

        public static T ItemAt<T>(this IEnumerable<T> collection, int index) {
            var id = 0;
            foreach (var item in collection) {
                if (id == index)
                    return item;
                id++;
            }
            throw new ArgumentOutOfRangeException(
                string.Format("No item at index {0} in collection of size {1}", 
                    index.ToString(), id.ToString()));
        }

        public static T[] AsArray<T>(this IEnumerable<T> collection) {
            var col = collection as ICollection<T>;
            if (col != null) {
                var length = col.Count;
                var result = new T[length];
                if (length > 0)
                    col.CopyTo(result, 0);
                return result;
            }
            else {
                var length = 4;
                var tmpArray = new T[length];
                var id = 0;
                foreach (var entry in collection) {
                    if (id == length) {
                        var prevLength = length;
                        length *= 2;
                        var tmp = new T[length];
                        Array.Copy(tmpArray, 0, tmp, 0, prevLength);
                        tmpArray = tmp;
                    }

                    tmpArray[id] = entry;
                    id++;
                }

                if (id == length)
                    return tmpArray;
                var result = new T[id];
                Array.Copy(tmpArray, 0, result, 0, id);
                return result;
            }
        }

        public static List<T> AsList<T>(this IEnumerable<T> collection) {
            return new List<T>(collection);
        }

        public static List<T> AsTempList<T>(this IEnumerable<T> collection) {
            var list = TemporaryPool.EmptyList<T>();
            if (collection != null)
                list.AddRange(collection);
            return list;
        }

        public static bool IsNullOrEmpty<T>(this ICollection<T> collection) {
            return collection == null || collection.IsEmpty();
        }

        public static bool IsEmpty<T>(this ICollection<T> collection) {
            return collection.Count == 0;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection) {
            return collection == null || collection.IsEmpty();
        }

        public static bool IsEmpty<T>(this IEnumerable<T> collection) {
            // ReSharper disable once UnusedVariable
            foreach (var entry in collection)
                return false;
            return true;
        }

        public static bool ContainItem<T>(this IEnumerable<T> collection, T item, IEqualityComparer<T> comparer = null) {
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;
            foreach (var entry in collection)
                if (comparer.Equals(entry, item))
                    return true;
            return false;
        }

        public static int IndexOf<T>(this IList<T> list, Func<T, bool> predicate) {
            for (int i = 0, count = list.Count; i < count; ++i)
                if (predicate(list[i]))
                    return i;
            return -1;
        }

        public static int IndexOf<T>(this IList<T> list, T target) {
            for (int i = 0, count = list.Count; i < count; ++i)
                if (target.Equals(list[i]))
                    return i;
            return -1;
        }

        public static bool TryFindItem<T>(this IEnumerable<T> collection, Func<T, bool> predicate, out T output) {
            foreach (var item in collection) {
                if (predicate(item)) {
                    output = item;
                    return true;
                }
            }
            output = default(T);
            return false;
        }

        public static T[] MergeWith<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2) {
            return Merge(collection1, collection2);
        }

        public static T[] Merge<T>(IEnumerable<T> collection1, IEnumerable<T> collection2) {
            var list = TemporaryPool.EmptyList<T>();
            if (collection1 != null)
                list.AddRange(collection1);
            if (collection2 != null)
                list.AddRange(collection2);
            return list.ToArray();
        }

        public static T[] Merge<T>(params IEnumerable<T>[] collections) {
            if (collections == null)
                return TemporaryPool.EmptyArray<T>();
            var list = TemporaryPool.EmptyList<T>();
            for (var i = 0; i < collections.Length; ++i) {
                var col = collections[i];
                if (col == null) 
                    continue;
                list.AddRange(col);
            }
            return list.ToArray();
        }

        public static void RemoveItemAndDecrementId<T>(this IList<T> list, ref int id) {
            list.RemoveAt(id);
            id--;
        }

        public static string JoinToString(this IEnumerable<byte> list) {
            return list.JoinToString(v => v.ToString("X"), "-");
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string separator = ", ") {
            return list.JoinToString(v => v.ToString(), separator);
        }

        public static string JoinToString<T1, T2>(this Dictionary<T1, T2> list, string separator = ", ") {
            return list.JoinToString(kvp => string.Format("{0} -> {1}", kvp.Key, kvp.Value), separator);
        }

        public static string JoinToString<T>(this IEnumerable<T> list, Func<T, string> format,
            string separator = ", ") {
            return string.Join(separator, list.SelectToArray(format));
        }

        private static string CollectionDescription<T>(IEnumerable<T> col) {
#if DEBUG
            return typeof(T).IsPrimitive
                ? col.Format()
                : string.Format("<objects of type {0}: {1}>", typeof(T), col.Format());
#else
            return string.Empty;
#endif
        }

        public static IEnumerator<T> GetTypedEnumerator<T>(this IList<T> array) {
            for (int i = 0, count = array.Count; i < count; ++i)
                yield return array[i];
        }

        public static T GetByIdOrNull<T>(this IList<T> list, int id) where T : class {
            if (id < 0 || id >= list.Count)
                return null;
            return list[id];
        }

        public static int LastItemIndex<T>(this IList<T> list) {
            return list.Count - 1;
        }

        public static T[] GetArrayOfElements<T>(T element) {
            return GetArrayOfElements<T, T>(element);
        }

        public static TOut[] GetArrayOfElements<TOut, TIn>(TIn element) where TIn : TOut{
            return new TOut[]{element};
        }

        public static T[] GetArrayOfElements<T>(T element1, T element2) {
            return new[]{element1, element2};
        }

        public static TOut[] GetArrayOfElements<TOut, TIn1, TIn2>(TIn1 element1, TIn2 element2)
            where TIn1 : TOut where TIn2 : TOut {
            return new TOut[] {element1, element2};
        }

        public static void SafeAdd<T>(ref List<T> list, T item) {
            if (list == null)
                list = new List<T>();
            list.Add(item);
        }

        public static List<T> ToList<T>(this IEnumerator<T> enumerator) {
            var list = new List<T>();
            while (enumerator.MoveNext())
                list.Add(enumerator.Current);
            enumerator.Dispose();
            return list;
        }

        public static void SafeForeach<T>(this IEnumerable<T> collection, Action<T> action) {
            if (collection == null)
                return;
            foreach (var item in collection)
                action(item);
        }
    }
}
