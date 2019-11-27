using System;
using CsExtensions;
using UnityEditor;
using UnityEngine;

namespace Unity.Editor.Utils {
    public class ScriptableObjectSeeker {
        // ReSharper disable once StringLiteralTypo
        private readonly string[] AssembliesPrefixesToSkip = {"UnityEngine", "UnityEditor", "Unity.PackageManager", "Unity.CollabProxy.Editor", "TextMeshPro"};
        private readonly Type TargetType = typeof(ScriptableObject);
        private readonly Type[] WrongTypes = {typeof(EditorWindow), typeof(UnityEditor.Editor)};
        private readonly string[] WrongTypePrefixes = {"TMP"};
        
        public Type[] GetScriptableObjectTypes() {
            var assembliesFindOptions = new AssembliesFindOptions {AssembliesPrefixesToSkip = AssembliesPrefixesToSkip};
            var assemblies = AssemblieUtils.GetAssemblies(assembliesFindOptions);
            
            var typeFindOptions = new TypeFindOptions {
                TargetType = TargetType,
                WrongTypes = WrongTypes,
                WrongTypePrefixes = WrongTypePrefixes
            };
            var result = TypeUtils.GetAllTypes(assemblies, typeFindOptions);
            return result;
        }
    }
}