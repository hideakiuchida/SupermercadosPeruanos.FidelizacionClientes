using System.Data.SqlClient;

namespace Common.FidelizacionClientes
{
    public abstract class DataConnection
    {
        protected SqlConnection connection;

        public DataConnection()
        {
            connection = GetConnection();
        }

        private static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost\\sqlexpress; " +
                "Database = BDFIDELIZACION; " +
                "Integrated Security = True; ";
            return conn;
        }
    }
}
