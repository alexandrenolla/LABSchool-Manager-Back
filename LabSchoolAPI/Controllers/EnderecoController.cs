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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        // POST api/endereco
        [HttpPost]
        public async Task<ActionResult<EnderecoReadDTO>> CreateEndereco(EnderecoCreateDTO enderecoCreateDTO)
        {
            var endereco = await _enderecoRepository.CreateAsync(enderecoCreateDTO);
            return CreatedAtAction(nameof(GetEnderecoById), new { id = endereco.Id }, endereco);

        }

        // GET api/endereco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoReadDTO>>> GetAllEnderecos()
        {
            return Ok(await _enderecoRepository.GetAllAsync());
        }

        // GET api/endereco/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoReadDTO>> GetEnderecoById(int id)
        {
            var endereco = await _enderecoRepository.GetByIdAsync(id);
            if (endereco == null)
                return NotFound();
            return Ok(endereco);
        }

        // PUT api/endereco/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEndereco(int id, EnderecoUpdateDTO enderecoUpdateDTO)
        {
            if (!await _enderecoRepository.ExistsAsync(id))
                return NotFound();
            
            await _enderecoRepository.UpdateAsync(enderecoUpdateDTO);
            return NoContent();
        }

        // DELETE api/endereco/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEndereco(int id)
        {
            if (!await _enderecoRepository.ExistsAsync(id))
                return NotFound();
            
            await _enderecoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
