using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ExDapper.WebApi.Infra
{
    public sealed class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DatabaseDapper"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
