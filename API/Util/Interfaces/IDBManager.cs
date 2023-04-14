namespace API_Indicacao_Premiada.Util.Interfaces
{
    public interface IDBManager
    {
        Task<int> ExecutarComando(string comando, object? parametros = null);

        Task<IEnumerable<T>> ExecutarComando<T>(string comando);
    }
}