using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.Models
{   
    [Table("Atendimento")]
    public class AtendimentoModel
    {
        [Key]
        public int Id { get; set; }// ID (Chave Primária)

        [Column(TypeName = "VARCHAR"), Required, StringLength(500)] 
        public string Descricao { get; set; } // Descrição do Atendimento

        [Column(TypeName = "VARCHAR"), Required, StringLength(10)] // yyyy-mm-dd 
        public string DataHora { get; set; }// Data e Hora do Atendimento

        [Required]
        public bool StatusAtivo { get; set; } // Status (Ativo/Inativo)


        // Chaves e relacionamentos abaixo //
        [ForeignKey("AlunoId")]
        public int AlunoId { get; set; }// ID do Aluno (Chave Estrangeira para o aluno relacionado)

        public virtual UsuarioModel Aluno { get; set; }

        [ForeignKey("PedagogoId")]
        public int PedagogoId { get; set; }// ID do Pedagogo (Chave Estrangeira para o pedagogo que realizou o atendimento)

        public virtual UsuarioModel Pedagogo { get; set; }

    }

}