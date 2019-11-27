using System;

namespace Logger {
    public class NullLogger : ILogger {
        private static NullLogger _instance;
        public static NullLogger Instance {
            get {
                if (_instance == null)
                    _instance = new NullLogger();
                return _instance;
            }
        }

        public void Debug(string msg) {
        }

        public void Info(string msg) {
        }

        public void Warn(string msg) {
        }

        public void Error(string msg) {
        }

        public void Exception(Exception e) {
        }
    }
}