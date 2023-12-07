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
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public ExercicioRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ExercicioReadDTO> CreateAsync(ExercicioCreateDTO exercicioCreateDTO)
        {
            var exercicio = _mapper.Map<ExercicioModel>(exercicioCreateDTO);
            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExercicioReadDTO>(exercicio);
        }

        public async Task<IEnumerable<ExercicioReadDTO>> GetAllAsync()
        {
            var exercicios = await _context.Exercicios.ToListAsync();
            return _mapper.Map<IEnumerable<ExercicioReadDTO>>(exercicios);
        }

        public async Task<ExercicioReadDTO> GetByIdAsync(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            return _mapper.Map<ExercicioReadDTO>(exercicio);
        }

        public async Task UpdateAsync(ExercicioUpdateDTO exercicioUpdateDTO)
        {
            var exercicio = _mapper.Map<ExercicioModel>(exercicioUpdateDTO);
            _context.Entry(exercicio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            if (exercicio != null)
            {
                _context.Exercicios.Remove(exercicio);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Exercicios.AnyAsync(e => e.Id == id);
        }
    }
}
