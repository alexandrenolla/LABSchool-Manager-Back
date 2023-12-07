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
    public class WhiteLabelRepository : IWhiteLabelRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public WhiteLabelRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WhiteLabelReadDTO> CreateAsync(WhiteLabelCreateDTO whiteLabelCreateDTO)
        {
            var whiteLabel = _mapper.Map<WhiteLabelModel>(whiteLabelCreateDTO);
            _context.WhiteLabels.Add(whiteLabel);
            await _context.SaveChangesAsync();
            return _mapper.Map<WhiteLabelReadDTO>(whiteLabel);
        }

        public async Task<IEnumerable<WhiteLabelReadDTO>> GetAllAsync()
        {
            var whiteLabels = await _context.WhiteLabels.ToListAsync();
            return _mapper.Map<IEnumerable<WhiteLabelReadDTO>>(whiteLabels);
        }

        public async Task<WhiteLabelReadDTO> GetByIdAsync(int id)
        {
            var whiteLabel = await _context.WhiteLabels.FindAsync(id);
            return _mapper.Map<WhiteLabelReadDTO>(whiteLabel);
        }

        public async Task UpdateAsync(WhiteLabelUpdateDTO whiteLabelUpdateDTO)
        {
            var whiteLabel = _mapper.Map<WhiteLabelModel>(whiteLabelUpdateDTO);
            _context.Entry(whiteLabel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var whiteLabel = await _context.WhiteLabels.FindAsync(id);
            if (whiteLabel != null)
            {
                _context.WhiteLabels.Remove(whiteLabel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.WhiteLabels.AnyAsync(wl => wl.Id == id);
        }
    }
}
