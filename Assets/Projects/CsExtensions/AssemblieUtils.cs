using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CsExtensions {
    public class AssembliesFindOptions {
        public string[] AssembliesPrefixesToSkip;

        internal bool IsTargetAssembly(Assembly assembly) {
            var fullName = assembly.FullName;
            for (int i = 0, count = AssembliesPrefixesToSkip.Length; i < count; ++i) {
                var prefixToSkip = AssembliesPrefixesToSkip[i];
                if (fullName.StartsWith(prefixToSkip))
                    return false;
            }
            return true;
        }
    }
    public class AssemblieUtils {
        public static IEnumerable<Assembly> GetAssemblies(AssembliesFindOptions options) {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            return allAssemblies.Where(options.IsTargetAssembly);
        }
    }
}