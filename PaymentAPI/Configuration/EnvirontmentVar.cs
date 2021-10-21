using System;
using MySql.Data.MySqlClient;
using Npgsql;

namespace PaymentAPI.Configuration
{
    public class EnvirontmentVar
    {
        public static string PostgreDatabaseConnection()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL_LOCAL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/')
            };
            
            return builder.ToString();
        }
        
         public static string MySQLDatabaseConnection()
         {
             var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL_LOCAL");
             var databaseUri = new Uri(databaseUrl);
             var userInfo = databaseUri.UserInfo.Split(':');

             var builder = new MySqlConnectionStringBuilder
             {
                 Server = databaseUri.Host,
                 UserID = userInfo[0],
                 Password = userInfo[1],
                 Database = databaseUri.LocalPath.TrimStart('/'),
                 SslMode = MySqlSslMode.None
             };

             return builder.ToString();
         }       

        public static string GetJwtSecret()
        {
            return Environment.GetEnvironmentVariable("SECRET");
        }
    }
}