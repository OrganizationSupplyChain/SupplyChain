using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using log4net;
using NLog;
using LogManager = NLog.LogManager;
using NPoco;
using Oracle.ManagedDataAccess.Client;

namespace InvoiceDiscounting.BusinessLogic.Repository
{
    public class BaseRepository
    {
        //private NLog.Logger _logger; 
        protected ILog _logger;
        public BaseRepository(string name)
        {
            //_logger = NLog.LogManager.GetCurrentClassLogger();
            _logger = log4net.LogManager.GetLogger(name);
        }

        public IDatabase Connect()
        {
            return new Database(ConfigurationManager.ConnectionStrings["InvoiceDiscounting"].ConnectionString, DatabaseType.OracleManaged, OracleClientFactory.Instance);
        }

        public OracleConnection NewConnect()
        {
            string connString = ConfigurationManager.ConnectionStrings["InvoiceDiscounting"].ConnectionString;
            OracleConnection conn = new OracleConnection {ConnectionString = connString};

            return conn;


        }

        public void Log(LogType type, Exception ex, object message)
        {
            _logger.Info("============ Logging from Repository ================");
            if (type == LogType.Info) _logger.Info(message, ex);
            if (type == LogType.Fatal) _logger.Fatal(message, ex);
            if (type == LogType.Error) _logger.Error(message, ex);
            if (type == LogType.Warning) _logger.Warn(message, ex);
        }
        public enum LogType
        {
            Info = 1, Error = 2, Warning = 3, Fatal = 4
        }
    }
}
