using System;

namespace ProductivityCentral.Logging {
    class NullLoggerFactory : ILoggerFactory {
        public ILogger CreateLogger(Type type) {
            return NullLogger.Instance;
        }
    }
}