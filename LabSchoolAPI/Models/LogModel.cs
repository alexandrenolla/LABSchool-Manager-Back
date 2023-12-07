using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.Models
{   
    [Table("Log")]    
    public class LogModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public TipoAtividade Atividade { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(250)] 
        public string Descricao { get; set; }


        // Chaves e relacionamentos abaixo //
        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }

        public virtual UsuarioModel Usuario { get; set; }
    }

}