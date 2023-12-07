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
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AtendimentoRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AtendimentoReadDTO> CreateAsync(AtendimentoCreateDTO atendimentoCreateDTO)
        {
            var atendimento = _mapper.Map<AtendimentoModel>(atendimentoCreateDTO);
            _context.Atendimentos.Add(atendimento);
            await _context.SaveChangesAsync();
            return _mapper.Map<AtendimentoReadDTO>(atendimento);
        }

        public async Task<IEnumerable<AtendimentoReadDTO>> GetAllAsync()
        {
            var atendimentos = await _context.Atendimentos.ToListAsync();
            return _mapper.Map<IEnumerable<AtendimentoReadDTO>>(atendimentos);
        }

        public async Task<AtendimentoReadDTO> GetByIdAsync(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            return _mapper.Map<AtendimentoReadDTO>(atendimento);
        }

        public async Task UpdateAsync(AtendimentoUpdateDTO atendimentoUpdateDTO)
        {
            var atendimento = _mapper.Map<AtendimentoModel>(atendimentoUpdateDTO);
            _context.Entry(atendimento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Atendimentos.AnyAsync(a => a.Id == id);
        }
    }
}

