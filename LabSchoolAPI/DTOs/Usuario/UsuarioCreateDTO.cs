using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MinLength(8, ErrorMessage = "Campo obrigatório, este campo aceita no mínimo de 8 caracteres")]
        [MaxLength(64, ErrorMessage = "Campo obrigatório, este campo aceita no máximo 64 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public TipoGenero Genero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(11, ErrorMessage = "Campo Obrigatório, digite o cpf sem pontuação: XXXXXXXXXXX")]
        [MinLength(11, ErrorMessage = "Campo Obrigatório, digite o cpf sem pontuação: XXXXXXXXXXX")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public bool StatusAtivo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(15, ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio, digite o telefone nesse formato: (XX) XXXXX-XXXX")]
        [MinLength(15, ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio, digite o telefone nesse formato: (XX) XXXXX-XXXX")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(100, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo caracteres")]
        [EmailAddress(ErrorMessage = "Campo Obrigatório, endereço de e-mail inválido, digite o email no formato xxxxx@xxxx.xxxx")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MinLength(6, ErrorMessage = "Campo obrigatório, este campo aceita no mínimo de 6 caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public TipoUsuario TipoUsuario { get; set; }

        public int Matricula { get; set; }

        public int CodigoProfessor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public int WhiteLabelId { get; set; }

        [Required]
        public EnderecoCreateDTO Endereco { get; set; } 
    }
 }