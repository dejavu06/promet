using Microsoft.Extensions.Configuration;
using System;

namespace Core.Utilities.Helpers
{
    public class ConfigurationHelper
    {
        private static IConfigurationRoot _configurationRoot;
        private static IConfigurationRoot _configurationBussinessConfig;

        public ConfigurationHelper()
        {
            if (_configurationRoot == null)
            {
                GetConfigFileSet();
                GetConfigBussinessConfigSet();
            }
        }

        public static IConfiguration GetConfig()
        {
            GetConfigFileSet();

            return _configurationRoot;
        }

        public static void GetConfigFileSet()
        {
            if (_configurationRoot == null)
            {
                _configurationRoot = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("connectionsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }

        public static IConfiguration GetBussinessConfig()
        {
            GetConfigBussinessConfigSet();

            return _configurationBussinessConfig;
        }

        public static void GetConfigBussinessConfigSet()
        {
            if (_configurationBussinessConfig == null)
            {
                _configurationBussinessConfig = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("bussinessconfig.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }
    }
}