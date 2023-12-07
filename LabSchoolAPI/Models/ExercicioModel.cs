using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;


namespace LabSchoolAPI.Models
{   
    [Table("Exercicio")]
    public class ExercicioModel 
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(50)] 
        public string Materia { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)] 
        public string Titulo { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(255)] 
        public string Descricao { get; set; }

        [Required]
        public int CodigoProfessor { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(10)] // yyyy-mm-dd ou dd-mm-yyyy
        public string DataConclusao { get; set; }


        // Chaves e relacionamentos abaixo

        [ForeignKey("AlunoId")]
        public int AlunoId { get; set; }

        public virtual UsuarioModel Aluno { get; set; }
        
    }
}