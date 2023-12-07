using Microsoft.AspNetCore.Mvc;
using LabSchoolAPI.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsuarioController> _logger; // Para log de erros

        public UsuarioController(IUsuarioRepository usuarioRepository, IConfiguration configuration, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _logger = logger;
        }

        // Listar todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _usuarioRepository.GetAllAsync();
            return Ok(users);
        }

        // Obter um usuário pelo ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                var errorMessage = "Nenhum usuário encontrado";
                return NotFound(new { error = errorMessage });
            }

            var successMessage = "Usuário encontrado com sucesso";
            return Ok(new { message = successMessage, usuario });
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(UsuarioCreateDTO userDto)
        {
            var usuario = await _usuarioRepository.CreateAsync(userDto);
            if (usuario == null)
            {
                
                return BadRequest("Dados inválidos");
            }

            var successMessage = "Usuario cadastrado com sucesso";
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, new { message = successMessage, usuario });
        }


        // Atualizar um usuário
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(string id, UsuarioUpdateDTO usuarioDto)
        {
            if (!int.TryParse(id, out int usuarioId) || usuarioId <= 0 || usuarioId == null)
            {
                
                return BadRequest("ID de atendimento inválido");
            }

            if (!await _usuarioRepository.ExistsAsync(usuarioId))
            {
                var errorMessage = "Usuario não encontrado";
                return NotFound(new { error = errorMessage });
            }

            await _usuarioRepository.UpdateAsync(usuarioDto);

            var successMessage = "Usuario Atualizado com sucesso";
            return Ok(new { message = successMessage });
        }

        // Deletar um usuário
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _usuarioRepository.ExistsAsync(id))
            {

                var errorMessage = "Usuario não encontrado";
                return NotFound(new { error = errorMessage });
            }
            await _usuarioRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(UsuarioLoginDTO loginDto)
        {
            try
            {
                var user = await _usuarioRepository.LoginAsync(loginDto);
                if (user == null)
                    return Unauthorized("Credenciais inválidas.");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Nome.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    Token = tokenString,
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email,
                    TipoUsuario = user.TipoUsuario
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro durante a autenticação.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "Ocorreu um erro durante a autenticação." });
            }
        }

        [HttpPut("changepassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ChangePassword(UsuarioResetarSenhaDTO resetDTO)
        {
            bool result = await _usuarioRepository.ResetPasswordAsync(resetDTO);
            if (!result)
                return BadRequest("Não foi possível alterar a senha.");

            return Ok("Senha alterada com sucesso.");
        }
    }
}