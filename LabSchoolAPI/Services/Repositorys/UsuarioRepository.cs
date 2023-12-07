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
using System.Text;
using System.Security.Cryptography;

namespace LabSchoolAPI.Services.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LabSchoolContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(LabSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public async Task<UsuarioReadDTO> CreateAsync(UsuarioCreateDTO usuarioCreateDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioCreateDTO);
            
            // Criar hash e salt da senha fornecida
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(usuarioCreateDTO.Senha, out passwordHash, out passwordSalt);
            
            // Atualizar o modelo do usuário com hash e salt
            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioReadDTO>(usuario);
        }


        public async Task<IEnumerable<UsuarioReadDTO>> GetAllAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioReadDTO>>(usuarios);
        }

        public async Task<UsuarioReadDTO> GetByIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            return _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task UpdateAsync(UsuarioUpdateDTO usuarioUpdateDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioUpdateDTO);
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Usuarios.AnyAsync(u => u.Id == id);
        }

        public async Task<UsuarioReadDTO> LoginAsync(UsuarioLoginDTO loginDTO)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
            if (usuario == null)
                return null;

            if (!VerifyPasswordHash(loginDTO.Password, usuario.PasswordHash, usuario.PasswordSalt))
                return null;

            return _mapper.Map<UsuarioReadDTO>(usuario);
        }

        public async Task<bool> ResetPasswordAsync(UsuarioResetarSenhaDTO resetDTO)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == resetDTO.Email);
            if (usuario == null)
                return false;

            if (!VerifyPasswordHash(resetDTO.CurrentPassword, usuario.PasswordHash, usuario.PasswordSalt))
                return false;

            // Atualizando a senha
            byte[] newPasswordHash, newPasswordSalt;
            CreatePasswordHash(resetDTO.NewPassword, out newPasswordHash, out newPasswordSalt);
            usuario.PasswordHash = newPasswordHash;
            usuario.PasswordSalt = newPasswordSalt;

            await _context.SaveChangesAsync();
            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}