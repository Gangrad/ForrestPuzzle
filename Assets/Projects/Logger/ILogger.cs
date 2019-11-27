
using System;

namespace Logger {
    public interface ILogger {
        void Debug(string msg);
        void Info(string msg);
        void Warn(string msg);
        void Error(string msg);
        void Exception(Exception e);
    }

    public static class LoggerHelper {
        public static void Log(this ILogger logger, LogLevel level, string msg) {
            switch (level) {
                case LogLevel.Disabled:
                    break;
                case LogLevel.Debug:
                    logger.Debug(msg);
                    break;
                case LogLevel.Info:
                    logger.Info(msg);
                    break;
                case LogLevel.Warning:
                    logger.Warn(msg);
                    break;
                case LogLevel.Error:
                    logger.Error(msg);
                    break;
                case LogLevel.Exception:
                    logger.Error(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("level", level, null);
            }
        }

        //--------------------------------

        public static void Log(this ILogger logger, LogLevel level, string format, object arg) {
            logger.Log(level, string.Format(format, arg));
        }

        public static void Debug(this ILogger logger, string format, object arg) {
            logger.Debug(string.Format(format, arg));
        }

        public static void Info(this ILogger logger, string format, object arg) {
            logger.Info(string.Format(format, arg));
        }

        public static void Warn(this ILogger logger, string format, object arg) {
            logger.Warn(string.Format(format, arg));
        }

        public static void Error(this ILogger logger, string format, object arg) {
            logger.Error(string.Format(format, arg));
        }
        
        //----------

        public static void SafeLog(this ILogger logger, LogLevel level, string format, object arg) {
            if (logger != null)
                logger.Log(level, string.Format(format, arg));
        }

        public static void SafeDebug(this ILogger logger, string format, object arg) {
            if (logger != null)
                logger.Debug(format, arg);
        }

        public static void SafeInfo(this ILogger logger, string format, object arg) {
            if (logger != null)
                logger.Info(format, arg);
        }

        public static void SafeWarn(this ILogger logger, string format, object arg) {
            if (logger != null)
                logger.Warn(format, arg);
        }

        public static void SafeError(this ILogger logger, string format, object arg) {
            if (logger != null)
                logger.Error(format, arg);
        }

        //--------------------------------

        public static void Log(this ILogger logger, LogLevel level, string format, object arg1, object arg2) {
            logger.Log(level, string.Format(format, arg1, arg2));
        }

        public static void Debug(this ILogger logger, string format, object arg1, object arg2) {
            logger.Debug(string.Format(format, arg1, arg2));
        }

        public static void Info(this ILogger logger, string format, object arg1, object arg2) {
            logger.Info(string.Format(format, arg1, arg2));
        }

        public static void Warn(this ILogger logger, string format, object arg1, object arg2) {
            logger.Warn(string.Format(format, arg1, arg2));
        }

        public static void Error(this ILogger logger, string format, object arg1, object arg2) {
            logger.Error(string.Format(format, arg1, arg2));
        }

        //----------
        
        public static void SafeLog(this ILogger logger, LogLevel level, string format, object arg1, object arg2) {
            if (logger != null)
                logger.Log(level, format, arg1, arg2);
        }

        public static void SafeDebug(this ILogger logger, string format, object arg1, object arg2) {
            if (logger != null)
                logger.Debug(format, arg1, arg2);
        }

        public static void SafeInfo(this ILogger logger, string format, object arg1, object arg2) {
            if (logger != null)
                logger.Info(format, arg1, arg2);
        }

        public static void SafeWarn(this ILogger logger, string format, object arg1, object arg2) {
            if (logger != null)
                logger.Warn(format, arg1, arg2);
        }

        public static void SafeError(this ILogger logger, string format, object arg1, object arg2) {
            if (logger != null)
                logger.Error(format, arg1, arg2);
        }

        //--------------------------------

        public static void Log(this ILogger logger, LogLevel level, string format, object arg1, object arg2,
            object arg3) {
            logger.Log(level, string.Format(format, arg1, arg2, arg3));
        }

        public static void Debug(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            logger.Debug(string.Format(format, arg1, arg2, arg3));
        }

        public static void Info(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            logger.Info(string.Format(format, arg1, arg2, arg3));
        }

        public static void Warn(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            logger.Warn(string.Format(format, arg1, arg2, arg3));
        }

        public static void Error(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            logger.Error(string.Format(format, arg1, arg2, arg3));
        }

        //----------
        
        public static void SafeLog(this ILogger logger, LogLevel level, string format, object arg1, object arg2,
            object arg3) {
            if (logger != null)
                logger.Log(level, format, arg1, arg2, arg3);
        }

        public static void SafeDebug(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            if (logger != null)
                logger.Debug(format, arg1, arg2, arg3);
        }

        public static void SafeInfo(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            if (logger != null)
                logger.Info(format, arg1, arg2, arg3);
        }

        public static void SafeWarn(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            if (logger != null)
                logger.Warn(format, arg1, arg2, arg3);
        }

        public static void SafeError(this ILogger logger, string format, object arg1, object arg2, object arg3) {
            if (logger != null)
                logger.Error(format, arg1, arg2, arg3);
        }

        //--------------------------------

        public static void Log(this ILogger logger, LogLevel level, string format, params object[] args) {
            logger.Log(level, string.Format(format, args));
        }

        public static void Debug(this ILogger logger, string format, params object[] args) {
            logger.Debug(string.Format(format, args));
        }

        public static void Info(this ILogger logger, string format, params object[] args) {
            logger.Info(string.Format(format, args));
        }

        public static void Warn(this ILogger logger, string format, params object[] args) {
            logger.Warn(string.Format(format, args));
        }

        public static void Error(this ILogger logger, string format, params object[] args) {
            logger.Error(string.Format(format, args));
        }

        //----------
        
        public static void SafeLog(this ILogger logger, LogLevel level, string format, params object[] args) {
            if (logger != null)
                logger.Log(level, format, args);
        }

        public static void SafeDebug(this ILogger logger, string format, params object[] args) {
            if (logger != null)
                logger.Debug(format, args);
        }

        public static void SafeInfo(this ILogger logger, string format, params object[] args) {
            if (logger != null)
                logger.Info(format, args);
        }

        public static void SafeWarn(this ILogger logger, string format, params object[] args) {
            if (logger != null)
                logger.Warn(format, args);
        }

        public static void SafeError(this ILogger logger, string format, params object[] args) {
            if (logger != null)
                logger.Error(format, args);
        }

        //--------------------------------

        public static void Debug(this ILogger logger, object obj) {
            logger.Debug(obj.ToString());
        }

        public static void Info(this ILogger logger, object obj) {
            logger.Info(obj.ToString());
        }

        public static void Warn(this ILogger logger, object obj) {
            logger.Warn(obj.ToString());
        }

        public static void Error(this ILogger logger, object obj) {
            logger.Error(obj.ToString());
        }

        //----------
        
        public static void SafeDebug(this ILogger logger, object obj) {
            if (logger != null)
                logger.Debug(obj);
        }

        public static void SafeInfo(this ILogger logger, object obj) {
            if (logger != null)
                logger.Info(obj);
        }

        public static void SafeWarn(this ILogger logger, object obj) {
            if (logger != null)
                logger.Warn(obj);
        }

        public static void SafeError(this ILogger logger, object obj) {
            if (logger != null)
                logger.Error(obj);
        }

        //--------------------------------

        public static void WriteLine(this ILogger logger, LogLevel level = LogLevel.Info) {
            logger.Log(level, "");
        }
    }

    public static class Log {
        private static ILogger _logger = NullLogger.Instance;
        public static ILogger Logger { get { return _logger; } set { _logger = value; } }

        private static ILogFactory _logFactory;
        public static ILogFactory LogFactory { get { return _logFactory; } set { _logFactory = value; } }
    }
}
