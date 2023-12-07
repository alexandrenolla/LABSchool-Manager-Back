using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LabSchoolAPI.DTOs;

namespace LabSchoolAPI.Services.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<UsuarioReadDTO> CreateAsync(UsuarioCreateDTO usuarioCreateDTO);
        Task<IEnumerable<UsuarioReadDTO>> GetAllAsync();
        Task<UsuarioReadDTO> GetByIdAsync(int id);
        Task UpdateAsync(UsuarioUpdateDTO usuarioUpdateDTO);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<UsuarioReadDTO> LoginAsync(UsuarioLoginDTO loginDTO);
        Task<bool> ResetPasswordAsync(UsuarioResetarSenhaDTO resetDTO);
    }
}