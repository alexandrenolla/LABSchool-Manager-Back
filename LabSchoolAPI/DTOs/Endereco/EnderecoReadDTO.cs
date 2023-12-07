using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.DTOs
{
    public class EnderecoReadDTO
    {
        public int Id { get; set; }
        
        public string Cep { get; set; }

        public string Cidade { get; set; }

        public TipoEstado Estado { get; set; } //enum

        public string Logradouro { get; set; }

        public string Numero { get; set; }
 
        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Referencia { get; set; }
    }
}