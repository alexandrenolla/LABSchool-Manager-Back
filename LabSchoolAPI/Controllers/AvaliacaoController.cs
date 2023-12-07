using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        // GET: api/Avaliacao
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<AvaliacaoReadDTO>>> GetAll()
        {
            return Ok(await _avaliacaoRepository.GetAllAsync());
        }

        // GET: api/Avaliacao/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AvaliacaoReadDTO>> GetById(int id)
        {
            var avaliacao = await _avaliacaoRepository.GetByIdAsync(id);

            if (avaliacao == null)
            {
                var errorMessage = "Nenhuma avaliação encontrada";
                return NotFound(new { error = errorMessage });
            }

            var successMessage = "Avaliações encontradas com sucesso";
            return Ok(new { message = successMessage, avaliacao });
        }

        // POST: api/Avaliacao
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AvaliacaoReadDTO>> Create(AvaliacaoCreateDTO avaliacaoCreateDTO)
        {
            var avaliacao = await _avaliacaoRepository.CreateAsync(avaliacaoCreateDTO);

            if (avaliacao == null)
            {
                var errorMessage = "Os dados do atendimento não são válidos";
                return BadRequest(new { error = errorMessage });
            }

            var successMessage = "Atendimento cadastrado com sucesso";
            return CreatedAtAction(nameof(GetById), new { id = avaliacao.Id }, new { message = successMessage, avaliacao });
        }

        // PUT: api/Avaliacao/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(string id, AvaliacaoUpdateDTO avaliacaoUpdateDTO)
        {
            if (!int.TryParse(id, out int avaliacaoId) || avaliacaoId <= 0 || avaliacaoId == null)
            {
                var errorMessage = "ID de avaliaçao inválido";
                return BadRequest(new { error = errorMessage });
            }

            if (!await _avaliacaoRepository.ExistsAsync(avaliacaoId))
            {
                var errorMessage = "Avaliaçao não encontrada";
                return NotFound(new { error = errorMessage });
            }

            await _avaliacaoRepository.UpdateAsync(avaliacaoUpdateDTO);

            var successMessage = "Avaliaçao Atualizada com sucesso";
            return Ok(new { message = successMessage });
        }

        // DELETE: api/Avaliacao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _avaliacaoRepository.ExistsAsync(id))
            {

                var errorMessage = "Avaliação não encontrada";
                return NotFound(new { error = errorMessage });
            }
            await _avaliacaoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

