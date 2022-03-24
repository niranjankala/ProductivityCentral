using System;
using System.Configuration;
using Castle.Core.Logging;
using log4net;
using log4net.Config;


namespace ProductivityCentral.Logging {
    public class ProductivityCentralLog4netFactory : AbstractLoggerFactory {
        private static bool _isFileWatched = false;

        public ProductivityCentralLog4netFactory() 
            : this(ConfigurationManager.AppSettings["log4net.Config"]) { }

        public ProductivityCentralLog4netFactory(string configFilename) {
            if (!_isFileWatched && !string.IsNullOrWhiteSpace(configFilename)) {
                // Only monitor configuration file in full trust
                XmlConfigurator.ConfigureAndWatch(GetConfigFile(configFilename));
                _isFileWatched = true;
            }
        }

        public override Castle.Core.Logging.ILogger Create(string name, LoggerLevel level) {
            throw new NotSupportedException("Logger levels cannot be set at runtime. Please review your configuration file.");
        }

        public override Castle.Core.Logging.ILogger Create(string name) {
            return new ProductivityCentralLog4netLogger(LogManager.GetLogger(name), this);
        }
    }
}
