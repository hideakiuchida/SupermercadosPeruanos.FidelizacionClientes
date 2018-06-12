//using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Common.FidelizacionClientes
{
    public abstract class DataConnection
    {
        protected MySqlConnection connection;

        public DataConnection()
        {
            connection = GetConnection();
        }

        private static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server = localhost; " +
                "User id = root; " +
                "Database = sigesu; " +
                "Password = mysql;";
            return conn;
        }
    }
}
