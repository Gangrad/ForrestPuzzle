using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Utils;
using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    public static class EasyButtonsEditorExtensions {
        private static void InvokeMethods(UnityEditor.Editor editor, IEnumerable<MethodInfo> methods,
            Func<UnityEngine.Object, object> getTargetObject) {
            foreach (var method in methods) {
                // Get the ButtonAttribute on the method (if any)
                var ba = (ButtonAttribute) Attribute.GetCustomAttribute(method, typeof (ButtonAttribute));

                if (ba != null) {
                    // Determine whether the button should be enabled based on its mode
                    GUI.enabled = ba.Mode == ButtonMode.AlwaysEnabled
                                  ||
                                  (EditorApplication.isPlaying
                                      ? ba.Mode == ButtonMode.EnabledInPlayMode
                                      : ba.Mode == ButtonMode.DisabledInPlayMode);

                    // Draw a button which invokes the method
                    string buttonName = string.IsNullOrEmpty(ba.Name)
                        ? ObjectNames.NicifyVariableName(method.Name)
                        : ba.Name;
                    if (GUILayout.Button(buttonName)) {
                        foreach (var t in editor.targets) {
                            var obj = getTargetObject(t);
                            method.Invoke(obj, null);
                        }
                    }

                    GUI.enabled = true;
                }
            }
        }

        public static void DrawEasyButtons(this UnityEditor.Editor editor) {
            // Loop through all methods with no parameters
            var methods = editor.target.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.GetParameters().Length == 0);
            //foreach (var method in methods) {
            //    // Get the ButtonAttribute on the method (if any)
            //    var ba = (ButtonAttribute) Attribute.GetCustomAttribute(method, typeof (ButtonAttribute));

            //    if (ba != null) {
            //        // Determine whether the button should be enabled based on its mode
            //        GUI.enabled = ba.Mode == ButtonMode.AlwaysEnabled
            //                      ||
            //                      (EditorApplication.isPlaying
            //                          ? ba.Mode == ButtonMode.EnabledInPlayMode
            //                          : ba.Mode == ButtonMode.DisabledInPlayMode);

            //        // Draw a button which invokes the method
            //        var buttonName = string.IsNullOrEmpty(ba.Name)
            //            ? ObjectNames.NicifyVariableName(method.Name)
            //            : ba.Name;
            //        if (GUILayout.Button(buttonName)) {
            //            foreach (var t in editor.targets) {
            //                method.Invoke(t, null);
            //            }
            //        }

            //        GUI.enabled = true;
            //    }
            //}
            InvokeMethods(editor, methods, obj => obj);

            //var ff = editor.target.GetType()
            //    .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            //Debug.LogFormat("{0}", ff.Select(f => Attribute.IsDefined(f.FieldType, typeof(SerializableAttribute))).Format());
            var fields =
                editor.target.GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Where(f => Attribute.IsDefined(f.FieldType, typeof (SerializableAttribute)));
            foreach (var field in fields) {
                methods = field.FieldType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                                     BindingFlags.NonPublic)
                    .Where(m => m.GetParameters().Length == 0);
                //foreach (var method in methods) {
                //    // Get the ButtonAttribute on the method (if any)
                //    var ba = (ButtonAttribute) Attribute.GetCustomAttribute(method, typeof (ButtonAttribute));

                //    if (ba != null) {
                //        // Determine whether the button should be enabled based on its mode
                //        GUI.enabled = ba.Mode == ButtonMode.AlwaysEnabled
                //                      ||
                //                      (EditorApplication.isPlaying
                //                          ? ba.Mode == ButtonMode.EnabledInPlayMode
                //                          : ba.Mode == ButtonMode.DisabledInPlayMode);

                //        // Draw a button which invokes the method
                //        var buttonName = string.IsNullOrEmpty(ba.Name)
                //            ? ObjectNames.NicifyVariableName(method.Name)
                //            : ba.Name;
                //        if (GUILayout.Button(buttonName)) {
                //            foreach (var t in editor.targets) {
                //                var obj = field.GetValue(t);
                //                method.Invoke(obj, null);
                //            }
                //        }

                //        GUI.enabled = true;
                //    }
                //}
                var f = field;
                InvokeMethods(editor, methods, obj => f.GetValue(obj));
            }
        }
    }
}
