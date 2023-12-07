using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioReadDTO
    {
        public int Id{ get; set; }
        public string Nome { get; set; }

        public TipoGenero Genero { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public EnderecoReadDTO Endereco { get; set; } 

        public bool StatusAtivo { get; set; }

        public double Matricula { get; set; }

        public int CodigoProfessor { get; set; }

        public int WhiteLabelId { get; set; }
    }
}