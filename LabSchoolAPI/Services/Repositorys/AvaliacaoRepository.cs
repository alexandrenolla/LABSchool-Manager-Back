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
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public AvaliacaoRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AvaliacaoReadDTO> CreateAsync(AvaliacaoCreateDTO avaliacaoCreateDTO)
        {
            var avaliacao = _mapper.Map<AvaliacaoModel>(avaliacaoCreateDTO);
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoReadDTO>(avaliacao);
        }

        public async Task<IEnumerable<AvaliacaoReadDTO>> GetAllAsync()
        {
            var avaliacoes = await _context.Avaliacoes.ToListAsync();
            return _mapper.Map<IEnumerable<AvaliacaoReadDTO>>(avaliacoes);
        }

        public async Task<AvaliacaoReadDTO> GetByIdAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            return _mapper.Map<AvaliacaoReadDTO>(avaliacao);
        }

        public async Task UpdateAsync(AvaliacaoUpdateDTO avaliacaoUpdateDTO)
        {
            var avaliacao = _mapper.Map<AvaliacaoModel>(avaliacaoUpdateDTO);
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Avaliacoes.AnyAsync(a => a.Id == id);
        }
    }
}
