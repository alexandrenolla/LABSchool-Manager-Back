using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface ILogRepository
    {
        Task<LogReadDTO> CreateAsync(LogCreateDTO logCreateDTO);
        Task<IEnumerable<LogReadDTO>> GetAllAsync();
        Task<LogReadDTO> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
