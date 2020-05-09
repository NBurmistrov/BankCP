using Microsoft.Data.SqlClient;

namespace BankCP.Modules.Implementation
{
    public class DBManager
    {
        public bool IsConnectionStringAvaliable(string connectionString)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    sqlConnection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
