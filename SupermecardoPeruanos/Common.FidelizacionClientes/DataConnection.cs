using System.Data.SqlClient;

namespace Common.FidelizacionClientes
{
    public class DataConnection
    {

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Server=localhost\\sqlexpress; " +
                "Database = BDFIDELIZACION; " +
                "Integrated Security = True; ";
            return conn;
        }
    }
}
