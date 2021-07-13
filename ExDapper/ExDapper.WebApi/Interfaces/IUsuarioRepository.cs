using ExDapper.WebApi.Models;
using System.Collections.Generic;

namespace ExDapper.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario ObterPorId(int id);
        IEnumerable<Usuario> ObterTodos();
        Usuario ObterPorEmail(string email);
        int Salvar(Usuario usuario);
    }
}
