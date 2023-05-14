using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infra.Data;

public class DbPokemon : IDisposable
{
    public IDbConnection Connection { get; }

    public DbPokemon(IConfiguration configuration)
    {
        Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        Connection.Open();
    }
    public void Dispose() => Connection?.Dispose();
}