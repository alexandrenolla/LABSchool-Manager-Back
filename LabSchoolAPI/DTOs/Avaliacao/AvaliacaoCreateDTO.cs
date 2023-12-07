using System.ComponentModel.DataAnnotations;

namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoCreateDTO
    {   
        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MinLength(8, ErrorMessage = "Campo obrigatório, este campo aceita no mínimo de 8 caracteres")]
        [MaxLength(64, ErrorMessage = "Campo obrigatório, este campo aceita no máximo 64 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MinLength(15, ErrorMessage = "Campo obrigatório, este campo aceita no mínimo de 15 caracteres")]
        [MaxLength(255, ErrorMessage = "Campo obrigatório, este campo aceita no máximo 255 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(50, ErrorMessage = "Este campo aceita até 50 caracteres")]
        public string Materia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        public double PontuacaoMaxima { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório, este campo não pode ficar vazio")]
        public double Nota { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório, este campo não pode ficar vazio")]
        [MaxLength(10, ErrorMessage = "Campo Obrigatório, digite a data nesse formato: dd-mm-aaaa")]
        [MinLength(10, ErrorMessage = "Campo Obrigatório, digite a data nesse formato: dd-mm-aaaa")]
        public string DataRealizacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int CodigoProfessor { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AlunoId { get; set; }

    }
}