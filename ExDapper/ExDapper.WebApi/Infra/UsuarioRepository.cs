using Dapper;
using ExDapper.WebApi.Interfaces;
using ExDapper.WebApi.Models;
using System.Collections.Generic;

namespace ExDapper.WebApi.Infra
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbSession _session;

        public UsuarioRepository(DbSession session)
        {
            _session = session;
        }

        public Usuario ObterPorEmail(string email) => _session.Connection.QueryFirstOrDefault<Usuario>("SELECT * FROM [Usuarios] WHERE EMAIL = @email",
                                                                                                       new { email },
                                                                                                       _session.Transaction);

        public Usuario ObterPorId(int id) => _session.Connection.QueryFirstOrDefault<Usuario>("SELECT * FROM [Usuarios] WHERE Id = @id",
                                                                                              new { id },
                                                                                              _session.Transaction);

        public IEnumerable<Usuario> ObterTodos() => _session.Connection.Query<Usuario>("SELECT * FROM [Usuarios]",
                                                                                       null,
                                                                                       _session.Transaction);

        public int Salvar(Usuario usuario)
        {
           return _session.Connection.Execute("INSERT INTO [Usuarios] VALUES(@nome, @email, @senha, @ativo)", usuario, _session.Transaction);
        }
    }
}
