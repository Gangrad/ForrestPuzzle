using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsExtensions {
    public class TypeFindOptions {
        public Type TargetType;
        public Type[] WrongTypes;
        public string[] WrongTypePrefixes;

        internal bool IsTargetType(Type type) {
            if (type.IsGenericType || !type.IsSubclassOf(TargetType))
                return false;
            if (WrongTypes.Any(type.IsSubclassOf)) 
                return false;
            if (WrongTypePrefixes.Any(type.Name.StartsWith))
                return false;
            return true;
        }
    }
    
    public static class TypeUtils {
        public static Type[] GetAllTypes(IEnumerable<Assembly> assemblies, TypeFindOptions options) {
            var result = new List<Type>();
            foreach (var assembly in assemblies)
                AddTypes(assembly, options, result);
            return result.ToArray();
        }

        private static void AddTypes(Assembly assembly, TypeFindOptions findOptions, List<Type> result) {
            var assemblyTypes = assembly.GetTypes();
            result.AddRange(assemblyTypes.Where(findOptions.IsTargetType));
        }
    }
}