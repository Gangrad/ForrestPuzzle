using System;

namespace CsExtensions {
    public class MutableProperty<T> : IDisposable where T : IEquatable<T> {
        private T _value;
        public event Action<T> OnChanged;

        public T Value {
            get {
                return _value;
            }
            set {
                if (_value.Equals(value)) 
                    return;
                _value = value;
                OnChanged.SafeInvoke(value);
            }
        }
        
        public MutableProperty() {
            _value = default(T);
        }
        
        public MutableProperty(T value) {
            _value = value;
        }

        public void Dispose() {
            OnChanged = delegate {  };
            _value = default(T);
        }
    }
}