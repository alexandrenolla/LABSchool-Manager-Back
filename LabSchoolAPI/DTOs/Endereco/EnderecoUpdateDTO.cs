using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.DTOs
{
    public class EnderecoUpdateDTO
    {   
        

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(9, ErrorMessage = "Campo Obrigatório, digite o cep nesse formato: XXXXX-XXX")]
        [MinLength(9, ErrorMessage = "Campo Obrigatório, digite o cep nesse formato: XXXXX-XXX")] // CEP no formato XXXXX-XXX
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(100, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 100 caracteres")]
        public string Cidade { get; set; }

        
        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public TipoEstado Estado { get; set; } //enum

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(200, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 200 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(10, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 10 caracteres")] 
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Este campo aceita no máximo 100 caracteres")] // Campo opcional
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(120, ErrorMessage = "Campo Obrigatório, este campo aceita no máximo 120 caracteres")] 
        public string Bairro { get; set; }

        [MaxLength(120, ErrorMessage = "Este campo aceita no máximo 120 caracteres")]  // Campo opcional
        public string Referencia { get; set; }
    }
}