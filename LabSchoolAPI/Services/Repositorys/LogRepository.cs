using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Models;
using LabSchoolAPI.Context;
using LabSchoolAPI.DTOs;
using LabSchoolAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace LabSchoolAPI.Services.Repositorys
{
    public class LogRepository : ILogRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public LogRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LogReadDTO> CreateAsync(LogCreateDTO logCreateDTO)
        {
            var log = _mapper.Map<LogModel>(logCreateDTO);
            _context.Logs.Add(log);
            await _context.SaveChangesAsync();
            return _mapper.Map<LogReadDTO>(log);
        }

        public async Task<IEnumerable<LogReadDTO>> GetAllAsync()
        {
            var logs = await _context.Logs.ToListAsync();
            return _mapper.Map<IEnumerable<LogReadDTO>>(logs);
        }

        public async Task<LogReadDTO> GetByIdAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            return _mapper.Map<LogReadDTO>(log);
        }

        public async Task DeleteAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Logs.AnyAsync(l => l.Id == id);
        }
    }
}
