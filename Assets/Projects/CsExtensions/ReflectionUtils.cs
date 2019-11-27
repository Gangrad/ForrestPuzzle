using System.Reflection;

namespace CsExtensions {
    public static class ReflectionUtils {
        public const BindingFlags GetFieldFlag =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField;

        public static T GetFieldValue<T>(this object obj, string fieldName) where T : class {
            var targetObjectClassType = obj.GetType();
            var field = targetObjectClassType.GetField(fieldName, GetFieldFlag);
            return field == null ? null : field.GetValue(obj) as T;
        }
    }
}