using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AtendimentoCreateDTO
    {
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "Campo obrigatório, não deixe este campo vazio, Digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Campo obrigatório, não deixe este campo vazio, Digite a data nesse formato: dd-mm-aaaa")]
        public string DataHora { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, insira um vaor válido, não deixe este campo vazio")]
        [MaxLength(500, ErrorMessage = "Campo Obrigatório, este campo aceita até 500 caracteres")]
        public string Descricao { get; set; }

        [Required]
        public bool StatusAtivo { get; set; }

        [Required(ErrorMessage ="Campo obrigatório, coloque um valor numeral válido")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage ="Campo obrigatório, coloque um valor numeral válido")]
        public int PedagogoId { get; set; }
    }
}