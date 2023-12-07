using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Models
{   
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

       [Column(TypeName = "VARCHAR"), Required, StringLength(150)] 
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(11)]  // CPF no formato sem pontuação.
        public string Cpf { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(15)]  // telefone no formato (XX) XXXXX-XXXX
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, EmailAddress, StringLength(100)]
        public string Email { get; set; }

        [Required]
        public TipoGenero Genero { get; set; } //enum

        [Required]
        public byte[] PasswordHash { get; set; } // para autenticar login com token jwt

        [Required]
        public byte[] PasswordSalt { get; set; } // para autenticar login com token jwt

        [Required]
        public TipoUsuario TipoUsuario { get; set; } //enum
 
        public int Matricula { get; set; } // Opcional, apenas para alunos

        public int CodigoProfessor { get; set; } // Opcional, apenas para professores

        [Required]
        public bool StatusAtivo { get; set; } = true;  // Se true, está Ativo. Se false, está Inativo.


        // Chaves e relacionamentos abaixo //

        [ForeignKey("EnderecoId")]
        public int EnderecoId { get; set; } // Chave estrangeira para tabela de endereços

        public virtual EnderecoModel Endereco { get; set; } // Propriedade de navegação para a tabela de endereços

        [ForeignKey("WhiteLabelId")]
        public int WhiteLabelId { get; set; } // Chave estrangeira para tabela de WhiteLabels

        public virtual WhiteLabelModel WhiteLabel { get; set; } // Propriedade de navegação para a tabela de WhiteLabels

    }
}