using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IWhiteLabelRepository
    {
        Task<WhiteLabelReadDTO> CreateAsync(WhiteLabelCreateDTO whiteLabelCreateDTO);
        Task<IEnumerable<WhiteLabelReadDTO>> GetAllAsync();
        Task<WhiteLabelReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(WhiteLabelUpdateDTO whiteLabelUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
