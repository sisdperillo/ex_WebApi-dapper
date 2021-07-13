using ExDapper.WebApi.Interfaces;
using ExDapper.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ExDapper.WebApi.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public IEnumerable<Usuario> Get() => _usuarioRepository.ObterTodos();

        [HttpGet("{id:int}")]
        public Usuario Get(int id) => _usuarioRepository.ObterPorId(id);

        [HttpGet("{email}")]
        public Usuario Get(string email) => _usuarioRepository.ObterPorEmail(email);

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            _unitOfWork.BeginTransaction();

            var id = _usuarioRepository.Salvar(usuario);

            _unitOfWork.Commit();

            return RedirectToAction("Get", new { id });
        }
    }
}
