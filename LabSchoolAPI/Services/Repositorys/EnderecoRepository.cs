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
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public EnderecoRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EnderecoReadDTO> CreateAsync(EnderecoCreateDTO enderecoCreateDTO)
        {
            var endereco = _mapper.Map<EnderecoModel>(enderecoCreateDTO);
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return _mapper.Map<EnderecoReadDTO>(endereco);
        }

        public async Task<IEnumerable<EnderecoReadDTO>> GetAllAsync()
        {
            var enderecos = await _context.Enderecos.ToListAsync();
            return _mapper.Map<IEnumerable<EnderecoReadDTO>>(enderecos);
        }

        public async Task<EnderecoReadDTO> GetByIdAsync(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            return _mapper.Map<EnderecoReadDTO>(endereco);
        }

        public async Task UpdateAsync(EnderecoUpdateDTO enderecoUpdateDTO)
        {
            var endereco = _mapper.Map<EnderecoModel>(enderecoUpdateDTO);
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Enderecos.AnyAsync(e => e.Id == id);
        }
    }
}
