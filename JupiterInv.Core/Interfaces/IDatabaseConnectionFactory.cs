using System.Data;

namespace JupiterInv.Core.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}