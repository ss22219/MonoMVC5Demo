using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonoMVC5Demo.Helper
{

    public static class DbHelper
    {
        private static readonly ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["default"];

        public static DbConnection OpenConnection(this Object obj)
        {
            return OpenConnection(obj, connectionStringSettings);
        }

        public static DbConnection OpenConnection(this Object obj, ConnectionStringSettings settings)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = dbFactory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            connection.Open();
            return connection;
        }
    }
}