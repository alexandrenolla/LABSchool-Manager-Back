using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class WhiteLabelCreateDTO
    {   
        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(100, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 100 caracteres")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(200, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 200 caracteres")]
        public string Slogan { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
         public string Cores { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string UrlLogo { get; set; }

        [MaxLength(500, ErrorMessage = "Este campo aceita até 500 caracteres")]
        public string Complemento { get; set; }

    }
}