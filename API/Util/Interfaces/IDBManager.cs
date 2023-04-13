namespace API_Indicacao_Premiada.Util.Interfaces
{
    public interface IDBManager
    {
        Task AbrirConexao();

        Task FecharConexao();

        Task<int> ExecutarComando(string comando);

        Task<IEnumerable<T>> ExecutarComando<T>(string comando);
    }
}