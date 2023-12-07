using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IExercicioRepository
    {
        Task<ExercicioReadDTO> CreateAsync(ExercicioCreateDTO exercicioCreateDTO);
        Task<IEnumerable<ExercicioReadDTO>> GetAllAsync();
        Task<ExercicioReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(ExercicioUpdateDTO exercicioUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
