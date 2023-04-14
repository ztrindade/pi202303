using API_Indicacao_Premiada.Util.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace API_Indicacao_Premiada.Util
{
    public class SqlHelper : IDBManager
    {
        private readonly IConfiguration _configuration;
        private string _stringConexao;

        public SqlHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            this._stringConexao = _configuration.GetConnectionString("local");
        }

        public async Task<int> ExecutarComando(string comando,object? parametros = null)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                return await conexao.ExecuteAsync(comando,parametros);
            }
        }

        public async Task<IEnumerable<T>> ExecutarComando<T>(string comando)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                return await conexao.QueryAsync<T>(comando);
            }
        }
    }
}