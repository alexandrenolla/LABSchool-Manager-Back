using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LabSchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _logRepository;
         private readonly IConfiguration _configuration;
        private readonly ILogger<AtendimentosController> _logger; // Para log de erros

        public LogController(ILogRepository logRepository , IConfiguration configuration, ILogger<AtendimentosController> logger )
        {
            _logRepository = logRepository;
            _configuration = configuration;
            _logger = logger;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<LogReadDTO>>> GetAllLogs()
        {
            return Ok(await _logRepository.GetAllAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<LogReadDTO>> GetLogById(int id)
        {
            var log = await _logRepository.GetByIdAsync(id);
            if (log == null)
            {
                var errorMessage = "Nenhum log encontrado";
                return NotFound(new { error = errorMessage });
            }

            var successMessage = "Log encontrado com sucesso";
            return Ok(new { message = successMessage, log });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LogReadDTO>> CreateLog(LogCreateDTO logCreateDTO)
        {
            var log = await _logRepository.CreateAsync(logCreateDTO);
            if (log == null)
            {     
                return BadRequest();
            }

            var successMessage = "Atendimento cadastrado com sucesso";
            return CreatedAtAction(nameof(GetLogById), new { id = log.Id }, new { message = successMessage, log });

        }
    }
}