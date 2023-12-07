using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Enums;

namespace LabSchoolAPI.Models
{   
    [Table("Endereco")]
    public class EnderecoModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(9)]  // CEP no formato XXXXX-XXX
        public string Cep { get; set; }

       [Column(TypeName = "VARCHAR"), Required, StringLength(100)] 
        public string Cidade { get; set; }

        [Required]
        public TipoEstado Estado { get; set; } //enum

        [Column(TypeName = "VARCHAR"), Required, StringLength(200)] 
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(10)] 
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]  // Campo opcional
        public string Complemento { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(120)] 
        public string Bairro { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(120)]  // Campo opcional
        public string Referencia { get; set; }
    }
}
