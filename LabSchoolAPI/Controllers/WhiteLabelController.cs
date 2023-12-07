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
    public class WhiteLabelController : ControllerBase
    {
        private readonly IWhiteLabelRepository _whiteLabelRepository;

        public WhiteLabelController(IWhiteLabelRepository whiteLabelRepository)
        {
            _whiteLabelRepository = whiteLabelRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WhiteLabelReadDTO>> CreateWhiteLabel(WhiteLabelCreateDTO whiteLabelCreateDTO)
        {
            var whiteLabel = await _whiteLabelRepository.CreateAsync(whiteLabelCreateDTO);
           if (whiteLabel == null)
            {     
                return BadRequest();
            }

            var successMessage = "WhiteLabel cadastrado com sucesso";
            return CreatedAtAction(nameof(GetWhiteLabelById), new { id = whiteLabel.Id }, new { message = successMessage, whiteLabel });

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WhiteLabelReadDTO>>> GetAllWhiteLabels()
        {
            return Ok(await _whiteLabelRepository.GetAllAsync());
        }
        
        [HttpGet("{id}")]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WhiteLabelReadDTO>> GetWhiteLabelById(int id)
        {
            var whiteLabel = await _whiteLabelRepository.GetByIdAsync(id);
            if (whiteLabel == null)
            {
                var errorMessage = "Nenhum WhiteLabel encontrado";
                return NotFound(new { error = errorMessage });
            }

            var successMessage = "WhiteLabel encontrado com sucesso";
            return Ok(new { message = successMessage, whiteLabel });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateWhiteLabel(string id, WhiteLabelUpdateDTO whiteLabelUpdateDTO)
        {
             if (!int.TryParse(id, out int whiteLabelId) || whiteLabelId <= 0 || whiteLabelId == null)
            { 
                return BadRequest();
            }

            if (!await _whiteLabelRepository.ExistsAsync(whiteLabelId))
            {
                var errorMessage = "WhiteLabel não encontrado";
                return NotFound(new { error = errorMessage });
            }

            await _whiteLabelRepository.UpdateAsync(whiteLabelUpdateDTO);

            var successMessage = "WhiteLabel Atualizado com sucesso";
            return Ok(new { message = successMessage });;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteWhiteLabel(int id)
        {
             if (!await _whiteLabelRepository.ExistsAsync(id))
            {

                var errorMessage = "whiteLabel não encontrado";
                return NotFound(new { error = errorMessage });
            }
            await _whiteLabelRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
