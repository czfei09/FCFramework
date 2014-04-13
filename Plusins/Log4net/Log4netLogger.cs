﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;

namespace FC.Framework.Log4net
{
    public class Log4netLogger : ILog
    {
        private readonly log4net.ILog _logger;

        #region ctor
        public Log4netLogger(string configFile="log4net.config")
        {
            var file = new FileInfo(configFile);
            if (!file.Exists)
            {
                file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFile));
            }

            if (file.Exists)
            {
                XmlConfigurator.ConfigureAndWatch(file);
            }
            else
            {
                BasicConfigurator.Configure(new ConsoleAppender { Layout = new PatternLayout() });
            }

            _logger = LogManager.GetLogger("log4net.Logger");
        }
        #endregion

        public void Info(string message)
        {
            this._logger.Info(message);
        }

        public void Debug(string message)
        {
            this._logger.Debug(message);
        }

        public void Warning(string message)
        {
            this._logger.Debug(message);
        }

        public void Error(string message)
        {
            this._logger.Error(message);
        }

        public void Exception(Exception exception)
        {
            this._logger.Fatal(exception);
        }
    }
}
