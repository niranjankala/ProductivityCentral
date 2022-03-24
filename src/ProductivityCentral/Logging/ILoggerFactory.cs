using System;

namespace ProductivityCentral.Logging {
    public interface ILoggerFactory {
        ILogger CreateLogger(Type type);
    }
}