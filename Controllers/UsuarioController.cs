using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CadastroApi.Models;
using CadastroApi.Repositories;
using System.Threading.Tasks;

namespace CadastroApi.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository repository, ILogger<UsuarioController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet] // Buscar todos os usuários
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _repository.GetAllAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")] // Buscar usuário por ID
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }
            return Ok(usuario);
        }

        [HttpPost] // Criar novo usuário
        public async Task<IActionResult> Add([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState });
            }

            await _repository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")] // Atualizar usuário
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState });
            }

            if (id != usuario.Id)
            {
                return BadRequest(new { message = "O ID da URL deve corresponder ao ID do usuário." });
            }

            var existingUser = await _repository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            // Atualiza os campos do usuário existente
            existingUser.Nome = usuario.Nome;
            existingUser.Email = usuario.Email;

            await _repository.UpdateAsync(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")] // Deletar usuário
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario == null)
            {
                _logger.LogWarning("Tentativa de exclusão de usuário não encontrado. ID: {Id}", id);
                return NotFound(new { message = "Usuário não encontrado." });
            }

            await _repository.DeleteAsync(id);
            _logger.LogInformation("Usuário deletado com sucesso. ID: {Id}", id);
            return NoContent();
        }
    }
}
