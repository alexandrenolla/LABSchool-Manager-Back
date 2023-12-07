using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(100, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo caracteres")]
        [EmailAddress(ErrorMessage = "Campo Obrigatório, endereço de e-mail inválido, digite o email no formato xxxxx@xxxx.xxxx")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MinLength(6, ErrorMessage = "Campo obrigatório, este campo aceita no mínimo de 6 caracteres")]
        public string Password { get; set; }  // renomeado de Senha para Password
    }
}
