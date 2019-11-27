namespace Logger {
    public class ConsoleLogFactory : LogFactory {
        public ConsoleLogFactory(LogLevel level = LogLevel.Info)
            : base(level) {
        }

        public override ILogger GetLogger(LogLevel level, string name) {
            return new ConsoleLogger(level, name);
        }
    }
}