using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabSchoolAPI.DTOs
{
    public class ExercicioReadDTO
    {
        
        public int Id { get; set; }
        
        public string Titulo {get; set;}

        
        public string Materia { get; set; }

       
        public string Descricao { get; set; }

        
        public int CodigoProfessor { get; set; }

        
        public int AlunoId { get; set; }

        
        public string DataConclusao { get; set; }
    }
}