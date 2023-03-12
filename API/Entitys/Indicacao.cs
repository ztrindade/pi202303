namespace API_Indicacao_Premiada.Entitys
{
    public class Indicacao
    {
        public int Id { get; set; }
        public string? NomeIndicado { get; set; }
        public string? TelefoneIndicado { get; set; }
        public int IdProcesso { get; set; }
        public string? MatriculaIndicante { get; set; }
        public string? Status { get; set; }
        public string? Linkedin { get; set; }

    }
}