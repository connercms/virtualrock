using System;
using Microsoft.Extensions.Configuration;

namespace VirtualRock.Data
{
    public interface IConnectionStringProvider
    {
        public string ConnectionString();
    }

    public class ConnectionStringProvider: IConnectionStringProvider
    {
        private IConfiguration _config;

        public ConnectionStringProvider(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString()
        {
            return _config.GetConnectionString("MySql");
        }
    }
}


//using System;
//using Microsoft.Extensions.Configuration;

//namespace VirtualRock.Data
//{
//    public interface IConnectionStringProvider
//    {
//        public static string ConnectionString { get; }
//    }

//    public class ConnectionStringProvider : IConnectionStringProvider
//    {
//        public static string ConnectionString;

//        public ConnectionStringProvider(string connectionString)
//        {
//            ConnectionString = connectionString;
//        }
//    }
//}
