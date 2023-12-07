using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabSchoolAPI.Models;

namespace LabSchoolAPI.Models
{   
    [Table("WhiteLabel")]
    public class WhiteLabelModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(500)] 
        public string Cores { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(100)] 
        public string NomeEmpresa { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(200)] 
        public string Slogan { get; set; }
        
        [Column(TypeName = "VARCHAR"), StringLength(500)]  // URL da imagem do logotipo, opcional
        public string UrlLogo { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(500)]  // opcional
        public string Complemento { get; set; }


         // Relacionamento abaixo //
        public virtual ICollection<UsuarioModel> Usuarios { get; set; }  // Propriedade de navegação para a tabela Usuarios
    }
}