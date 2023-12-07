using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<AvaliacaoReadDTO> CreateAsync(AvaliacaoCreateDTO avaliacaoCreateDTO);
        Task<IEnumerable<AvaliacaoReadDTO>> GetAllAsync();
        Task<AvaliacaoReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(AvaliacaoUpdateDTO avaliacaoUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
