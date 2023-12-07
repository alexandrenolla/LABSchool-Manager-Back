using Microsoft.AspNetCore.Mvc;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercicioController : ControllerBase
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioController(IExercicioRepository exercicioRepository)
        {
            _exercicioRepository = exercicioRepository;
        }

        // GET: api/Exercicio
         [HttpGet]
        public async Task<ActionResult<IEnumerable<ExercicioReadDTO>>> GetAll()
        {
            return Ok(await _exercicioRepository.GetAllAsync());
        }

        // GET: api/Exercicio/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExercicioReadDTO>> GetById(int id)
        {
            var exercicio = await _exercicioRepository.GetByIdAsync(id);
            
            if (exercicio == null)
            {
                var errorMessage = "Nenhum exercício encontrado";
                return NotFound(new { error = errorMessage });
            }

            var successMessage = "Exercício encontrado com sucesso";
            return Ok(new { message = successMessage, exercicio });
        }

        // POST: api/Exercicio
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ExercicioReadDTO>> Create(ExercicioCreateDTO exercicioCreateDTO)
        {
            var exercicio = await _exercicioRepository.CreateAsync(exercicioCreateDTO);
            if (exercicio == null)
            {
                return BadRequest();
            }

            var successMessage = "Exercício cadastrado com sucesso";
            return CreatedAtAction(nameof(GetById), new { id = exercicio.Id }, new { message = successMessage, exercicio });
        }
        
        // PUT: api/Exercicio/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ExercicioUpdateDTO exercicioUpdateDTO)
        {
           if (!int.TryParse(id, out int exercicioId) || exercicioId <= 0 || exercicioId == null)
            {
                
                return BadRequest();
            }

            if (!await _exercicioRepository.ExistsAsync(exercicioId))
            {
                var errorMessage = "Exercício não encontrado";
                return NotFound(new { error = errorMessage });
            }

            await _exercicioRepository.UpdateAsync(exercicioUpdateDTO);

            var successMessage = "Exercício Atualizado com sucesso";
            return Ok(new { message = successMessage });
        }

        // DELETE: api/Exercicio/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _exercicioRepository.ExistsAsync(id))
            {

                var errorMessage = "Exercicio não encontrado";
                return NotFound(new { error = errorMessage });
            }
            await _exercicioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
