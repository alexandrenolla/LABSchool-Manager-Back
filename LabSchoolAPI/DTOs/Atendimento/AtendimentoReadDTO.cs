namespace LabSchoolAPI.DTOs
{
    public class AtendimentoReadDTO
    {   
        public int Id { get; set; }
        
        public string DataHora { get; set; }

        public string Descricao { get; set; }

        public bool StatusAtivo { get; set; }

        public int AlunoId { get; set; }

        public int PedagogoId { get; set; }
    }
}