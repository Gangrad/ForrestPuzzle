using System;

namespace CsExtensions {
    public class ImmutableProperty<T> : IDisposable {
        private T _value;

        public T Value {
            get { return _value; }
            set { throw new ArgumentException("Set value for immutable property prohibited"); }
        }
        
        public ImmutableProperty() {
            _value = default(T);
        }
        
        public ImmutableProperty(T value) {
            _value = value;
        }

        public void Dispose() {
            _value = default(T);
        }
    }
}