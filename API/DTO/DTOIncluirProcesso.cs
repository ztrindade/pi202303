namespace API_Indicacao_Premiada.DTO
{
    public class DTOIncluirProcesso
    {
        public string? Empresa { get; set; }
        public string? Vaga { get; set; }
        public string? MatriculaRH { get; set; }
        public decimal? ValorPremiacao { get; set; }
    }
}