namespace Logger {
    public interface ILogFactory {
        ILogger GetLogger(LogLevel level, string name);
        ILogger GetLogger(string name);
    }
}