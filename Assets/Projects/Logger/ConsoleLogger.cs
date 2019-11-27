#define HIGHLIGHT_CLASS_NAME

using System;
using System.Runtime.CompilerServices;

namespace Logger {
    public class ConsoleLogger : ILogger {
#if !UNITY
        private readonly LogLevel _level;
        private readonly string _name;
        private readonly bool _hasName;
#endif

        public ConsoleLogger(LogLevel level, string name = "") {
#if !UNITY
            _level = level;
            _name = name;
            _hasName = !string.IsNullOrEmpty(name);
#endif
        }

        public ConsoleLogger()
            : this(LogLevel.Info) {
        }

        private void Print(LogLevel level, ConsoleColor color, string msg) {
#if !UNITY
            if (_level <= level) {
                Console.ForegroundColor = color;
                if (_hasName) {
#if HIGHLIGHT_CLASS_NAME
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(_name);
                    Console.ForegroundColor = color;
                    Console.Write("]: {0}\n", msg);
#else
                    Console.Write("[{0}]: {1}\n", _name, msg);
#endif
                }
                else
                    Console.WriteLine(msg);
            }
#endif
        }

        public void Debug(string msg) {
            Print(LogLevel.Debug, ConsoleColor.Gray, msg);
        }

        public void Info(string msg) {
            Print(LogLevel.Info, ConsoleColor.White, msg);
        }

        public void Warn(string msg) {
            Print(LogLevel.Warning, ConsoleColor.Yellow, msg);
        }

        public void Error(string msg) {
            Print(LogLevel.Error, ConsoleColor.Red, msg);
        }

        public void Exception(Exception e) {
            Print(LogLevel.Error, ConsoleColor.DarkRed, e.ToString());
        }
    }

    public static class ConsoleLoggerUtils {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ConsoleLogger GetCurrentClassLogger(LogLevel level) {
            return (ConsoleLogger)new ConsoleLogFactory().GetPrevClassLogger(level);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ConsoleLogger GetCurrentClassLogger() {
            return (ConsoleLogger)new ConsoleLogFactory().GetPrevClassLogger();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ConsoleLogger GetEmptyLogger(LogLevel level) {
            return (ConsoleLogger)new ConsoleLogFactory().GetLogger(level, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ConsoleLogger GetEmptyLogger() {
            return (ConsoleLogger)new ConsoleLogFactory().GetLogger("");
        }
    }
}