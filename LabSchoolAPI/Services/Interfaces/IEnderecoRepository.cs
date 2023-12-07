using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<EnderecoReadDTO> CreateAsync(EnderecoCreateDTO enderecoCreateDTO);
        Task<IEnumerable<EnderecoReadDTO>> GetAllAsync();
        Task<EnderecoReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(EnderecoUpdateDTO enderecoUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
