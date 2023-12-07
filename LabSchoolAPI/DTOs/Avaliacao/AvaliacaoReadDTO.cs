namespace LabSchoolAPI.DTOs
{
    public class AvaliacaoReadDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Materia { get; set; }

        public double PontuacaoMaxima { get; set; }

        public double Nota { get; set; }

        public string DataRealizacao { get; set; }

        public int CodigoProfessor { get; set; }

        public int AlunoId { get; set; }

    }
}