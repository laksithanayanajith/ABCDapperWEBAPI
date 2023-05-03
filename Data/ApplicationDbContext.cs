using Microsoft.Data.SqlClient;
using System.Data;

namespace ABCDapperWEBAPI.Data
{
    public class ApplicationDbContext
    {
        private readonly IConfiguration configuration;
        private readonly string connectionString = string.Empty;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = this.configuration.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(this.connectionString);
    }
}
