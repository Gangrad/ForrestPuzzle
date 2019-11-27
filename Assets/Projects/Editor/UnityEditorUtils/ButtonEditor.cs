using UnityEditor;

namespace Unity.Editor.Utils {
    /// <summary>
    /// Custom inspector for Object including derived classes.
    /// </summary>
    [CanEditMultipleObjects]
    [CustomEditor(typeof (UnityEngine.Object), true)]
    public class ObjectEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            //this.DrawEasyButtons();

            //// Draw the rest of the inspector as usual
            //DrawDefaultInspector();

            // Draw the rest of the inspector as usual
            DrawDefaultInspector();
            this.DrawEasyButtons();
        }
    }
}
