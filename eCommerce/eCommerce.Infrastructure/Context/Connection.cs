using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace eCommerce.Infrastructure.Context
{
    public static class Connection
    {
        public static IDbConnection AddConnection(this IDbConnection connection, IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            return connection;
        }

    }
}
