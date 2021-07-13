namespace ExDapper.WebApi.Models
{
    public class Usuario
    {
        public Usuario(int id, string nome, string email, string senha, bool ativo = true)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Ativo = ativo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
