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

        public async Task AbrirConexao()
        {
            await conexao.OpenAsync();
        }

        public async Task FecharConexao()
        {
            await conexao.CloseAsync();
        }

        public async Task<int> ExecutarComando(string comando)
        {
            return await conexao.ExecuteAsync(comando);
        }

        public async Task<IEnumerable<T>> ExecutarComando<T>(string comando)
        {
            return await conexao.QueryAsync<T>(comando);
        }
    }
}