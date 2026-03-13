using Microsoft.Data.SqlClient;


namespace IMSDb.WebApp.Data
{
    public class DatabaseConnectionManager
    {
        private readonly string _connectionString;

        public DatabaseConnectionManager(IConfiguration configuration)
        {
           
            _connectionString = configuration.GetConnectionString("MyAppDbContext")
                ?? throw new InvalidOperationException("Connection string not found.");
        }

        
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
