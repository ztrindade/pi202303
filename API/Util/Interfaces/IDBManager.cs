namespace API_Indicacao_Premiada.Util.Interfaces
{
    public interface IDBManager
    {
        void AbrirConexao();

        void FecharConexao();

        int ExecutarComando(string comando);

        IEnumerable<T> ExecutarComando<T>(string comando);
    }
}