using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<AtendimentoReadDTO> CreateAsync(AtendimentoCreateDTO atendimentoCreateDTO);
        Task<IEnumerable<AtendimentoReadDTO>> GetAllAsync();
        Task<AtendimentoReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(AtendimentoUpdateDTO atendimentoUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}