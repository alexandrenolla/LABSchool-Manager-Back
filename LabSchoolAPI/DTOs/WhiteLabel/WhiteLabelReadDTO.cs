using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class WhiteLabelReadDTO
    {
        public int Id { get; set; }
        
        public string NomeEmpresa { get; set; }

        public string Slogan { get; set; }

         public string Cores { get; set; }
        
        public string UrlLogo { get; set; }
 
        public string Complemento { get; set; }

    }
}