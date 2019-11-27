using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Logger {
    public abstract class LogFactory : ILogFactory {
        protected readonly LogLevel Level;

        protected LogFactory(LogLevel level) {
            Level = level;
        }

        public abstract ILogger GetLogger(LogLevel level, string name);

        public ILogger GetLogger(string name) {
            return GetLogger(Level, name);
        }
    }

    public static class LogFactoryUtils {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string GetCurrentClassName(int frameId = 1) {
            var method = new StackTrace().GetFrame(frameId).GetMethod();
            return method.DeclaringType != null ? method.DeclaringType.Name : "";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger(this ILogFactory factory, LogLevel level) {
            string name = GetCurrentClassName();
            return factory.GetLogger(level, name);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetCurrentClassLogger(this ILogFactory factory) {
            string name = GetCurrentClassName(2);
            return factory.GetLogger(name);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger SafeGetCurrentClassLogger(this ILogFactory factory) {
            if (factory == null)
                return NullLogger.Instance;
            string name = GetCurrentClassName(2);
            return factory.GetLogger(name);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetPrevClassLogger(this ILogFactory factory, LogLevel level) {
            string name = GetCurrentClassName(3);
            return factory.GetLogger(level, name);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ILogger GetPrevClassLogger(this ILogFactory factory) {
            string name = GetCurrentClassName(3);
            return factory.GetLogger(name);
        }
    }
}