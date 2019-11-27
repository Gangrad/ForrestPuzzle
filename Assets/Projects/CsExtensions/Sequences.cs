using System.Collections.Generic;

namespace CsExtensions {
    public struct Pair<T1, T2> {
        public T1 First;
        public T2 Second;

        public Pair(KeyValuePair<T1, T2> pair) : this(pair.Key, pair.Value) { }

        public Pair(T1 first, T2 second) {
            First = first;
            Second = second;
        }
    }

    public struct Triple<T1, T2, T3> {
        public T1 First;
        public T2 Second;
        public T3 Third;

        public Triple(T1 first, T2 second, T3 third) {
            First = first;
            Second = second;
            Third = third;
        }
    }

    public struct Quadro<T1, T2, T3, T4> {
        public T1 First;
        public T2 Second;
        public T3 Third;
        public T4 Fourth;

        public Quadro(T1 first, T2 second, T3 third, T4 fourth) {
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
        }
    }

    public static class SequencesUtils {
        public static KeyValuePair<T1, T2> ToKeyValuePair<T1, T2>(this Pair<T1, T2> pair) {
            return new KeyValuePair<T1, T2>(pair.First, pair.Second);
        }
    }
}