using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Util.Interfaces;

namespace API_Indicacao_Premiada.Repositories
{
    public class IndicacaoRepositorie : IIndicacaoRepositorie
    {
        private readonly IDBManager _sqlHelper;

        public IndicacaoRepositorie(IDBManager sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public int IncluirIndicacao(DTOIncluirIndicacao indicacao)
        {
            string comandoSql = string.Format(
                "INSERT INTO Indicacoes (NomeIndicado,TelefoneIndicado,IdProcesso,MatriculaIndicante,Linkedin,Status) Values('{0}','{1}',{2},'{3}','{4}','Indicado')",
                indicacao.NomeIndicado, indicacao.TelefoneIndicado, indicacao.IdProcesso, indicacao.MatriculaIndicante,indicacao.Linkedin);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Indicacao> ListarIndicacoes()
        {
            string comandoSql = "SELECT * FROM Indicacoes";

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Indicacao>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Indicacao> ListarIndicacoesPorProcesso(int idProcesso)
        {
            string comandoSql = string.Format("SELECT * FROM Indicacoes where IdProcesso = {0}", idProcesso);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Indicacao>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public int FinalizarIndicacao(int id)
        {
            string comandoSql = string.Format("UPDATE Indicacoes SET Status = 'Premiada' where id = {0}", id);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }
    }
}