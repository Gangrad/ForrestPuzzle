using System;
using System.IO;
using Logger;
using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    // http://wiki.unity3d.com/index.php/CreateScriptableObjectAsset
    public static class ScriptableObjectUtils {
        /// <summary>
        //	This makes it easy to create, name and place unique new ScriptableObject asset files.
        /// </summary>
        public static void CreateAsset<T>() where T : ScriptableObject {
            var asset = ScriptableObject.CreateInstance<T>();
            CreateObject(asset);
        }

        public static void CreateAsset(Type t) {
            var asset = ScriptableObject.CreateInstance(t);
            if (asset != null)
                CreateObject(asset);
            else
                Log.Logger.Error("Cant create scriptable object of type {0}", t.Name);
        }

        private static void CreateObject<T>(T asset) where T : UnityEngine.Object {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (path == "") {
                path = "Assets";
            }
            else if (Path.GetExtension(path) != "") {
                string activeObjPath = AssetDatabase.GetAssetPath(Selection.activeObject);
                string filename = Path.GetFileName(activeObjPath);
                path = filename != null ? path.Replace(filename, "") : "Assets";
            }

            string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof (T) + ".asset");

            AssetDatabase.CreateAsset(asset, assetPathAndName);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }
    }
}
