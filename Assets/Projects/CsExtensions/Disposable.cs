using System;
using System.Collections.Generic;

namespace CsExtensions {
    public class Disposable : IDisposable {
        private readonly Action _dispose;

        public Disposable(Action dispose) {
            _dispose = dispose;
        }

        public void Dispose() {
            _dispose.SafeInvoke();
        }
    }

    public class DisposableCollection : IDisposable {
        private readonly List<Action> _disposeCollection = new List<Action>();

        public void Retain(Action dispose) {
            _disposeCollection.Add(dispose);
        }

        public void Dispose() {
            for (int i = 0, count = _disposeCollection.Count; i < count; ++i)
                _disposeCollection[i]();
            _disposeCollection.Clear();
        }
    }
   
    public static class DisposableUtils {
        public static void SafeDispose(this IDisposable disposable) {
            if (disposable != null)
                disposable.Dispose();
        }

        public static void DisposeBy(this IDisposable disposable, DisposableCollection disposableCollection) {
            disposableCollection.Retain(disposable.Dispose);
        }
    }
}