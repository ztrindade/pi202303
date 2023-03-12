namespace API_Indicacao_Premiada.Entitys
{
    public class Premiacao
    {
        public int Id { get; set; }
        public int IdProcesso { get; set; }
        public int IdIndicacao { get; set; }
        public decimal? ValorPremiacao { get; set; }

    }
}