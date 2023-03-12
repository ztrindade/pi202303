namespace API_Indicacao_Premiada.Entitys
{
    public class Processo
    {
        public int Id { get; set; }
        public string? Empresa { get; set; }
        public string? Vaga { get; set; }
        public string? MatriculaRH { get; set; }
        public string? Status { get; set; }
        public decimal? ValorPremiacao { get; set; }

    }
}