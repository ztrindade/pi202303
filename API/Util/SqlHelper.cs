using API_Indicacao_Premiada.Util.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace API_Indicacao_Premiada.Util
{
    public class SqlHelper : IDBManager
    {
        private readonly IConfiguration _configuration;
        private string stringConexao;
        private readonly SqlConnection conexao;

        public SqlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            this.stringConexao = _configuration.GetConnectionString("local");
            conexao = new SqlConnection(this.stringConexao);
        }

        public void AbrirConexao()
        {
            conexao.Open();
        }

        public void FecharConexao()
        {
            conexao.Close();
        }

        public int ExecutarComando(string comando)
        {
            return conexao.Execute(comando);
        }

        public IEnumerable<T> ExecutarComando<T>(string comando)
        {
            return conexao.Query<T>(comando);
        }
    }
}