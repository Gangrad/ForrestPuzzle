using System;

namespace Unity.Utils {
    public enum ButtonMode {
        AlwaysEnabled,
        EnabledInPlayMode,
        DisabledInPlayMode
    }

    /// <summary>
    /// Attribute to create a button in the inspector for calling the method it is attached to.
    /// The method must have no arguments.
    /// </summary>
    /// <example>
    /// [Button]
    /// public void MyMethod()
    /// {
    ///     Debug.Log("Clicked!");
    /// }
    /// </example>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ButtonAttribute : Attribute {
        private readonly string _name;
        private readonly ButtonMode _mode = ButtonMode.AlwaysEnabled;

        public string Name {
            get { return _name; }
        }

        public ButtonMode Mode {
            get { return _mode; }
        }

        public ButtonAttribute() {
        }

        public ButtonAttribute(string name) {
            _name = name;
        }

        public ButtonAttribute(string name, ButtonMode mode) {
            _name = name;
            _mode = mode;
        }

        public ButtonAttribute(ButtonMode mode) {
            _mode = mode;
        }
    }
}
