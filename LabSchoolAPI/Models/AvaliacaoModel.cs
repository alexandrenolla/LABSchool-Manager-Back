using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.Models
{   
    [Table("Avaliacao")]
    public class AvaliacaoModel
    {
        [Key]
        public int Id { get; set; } //chave primaria

        [Column(TypeName = "VARCHAR"), Required, StringLength(50)] 
        public string Titulo { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(50)] 
        public string Materia { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(500)] 
        public string Descricao { get; set; }

        [Required] 
        public double Nota { get; set; }

        [Required]
        public double PontuacaoMaxima {get; set;}

        [Column(TypeName = "VARCHAR"), Required, StringLength(10)] // yyyy-mm-dd 
        public string DataRealizacao {get; set;}

        [Required] 
        public int CodigoProfessor { get; set; }

        // Chaves e relacionamentos abaixo

        [ForeignKey("AlunoId")]
        public int AlunoId { get; set; }

        public virtual UsuarioModel Aluno { get; set; }

    }   

}