using System.Data;
using JupiterInv.Core.Interfaces;
using Npgsql;

namespace JupiterInv.Infrastructure.Database
{
    public class DatabaseConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string? _connectionString;

        public DatabaseConnectionFactory(string? connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
