namespace API_Indicacao_Premiada.DTO
{
    public class DTOIncluirPremiacao
    {
        public int IdProcesso { get; set; }
        public int IdIndicacao { get; set; }
        public decimal? ValorPremiacao { get; set; }
    }
}