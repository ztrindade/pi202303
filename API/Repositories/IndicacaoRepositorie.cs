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

        public async Task<int> IncluirIndicacao(DTOIncluirIndicacao indicacao)
        {
            string comandoSql = string.Format(
                "INSERT INTO Indicacoes (NomeIndicado,TelefoneIndicado,IdProcesso,MatriculaIndicante,Linkedin,Status) Values('{0}','{1}',{2},'{3}','{4}','Indicado')",
                indicacao.NomeIndicado, indicacao.TelefoneIndicado, indicacao.IdProcesso, indicacao.MatriculaIndicante, indicacao.Linkedin);

            var ret = await _sqlHelper.ExecutarComando(comandoSql);

            return ret;
        }

        public async Task<IEnumerable<Indicacao>> ListarIndicacoes()
        {
            string comandoSql = "SELECT * FROM Indicacoes";
            var ret = await _sqlHelper.ExecutarComando<Indicacao>(comandoSql);

            return ret;
        }

        public async Task<IEnumerable<Indicacao>> ListarIndicacoesPorProcesso(int idProcesso)
        {
            string comandoSql = string.Format("SELECT * FROM Indicacoes where IdProcesso = {0}", idProcesso);
            var ret = await _sqlHelper.ExecutarComando<Indicacao>(comandoSql);

            return ret;
        }

        public async Task<int> FinalizarIndicacao(int id)
        {
            string comandoSql = string.Format("UPDATE Indicacoes SET Status = 'Premiada' where id = {0}", id);
            var ret = await _sqlHelper.ExecutarComando(comandoSql);

            return ret;
        }

        public async Task<int> FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao)
        {
            string comandoSql = string.Format(@"UPDATE Indicacoes SET Status = 'Finalizada'
                                                where IdProcesso = {0} AND Id <> {1}",
                                                idProcesso, idIndicacao);

            var ret = await _sqlHelper.ExecutarComando(comandoSql);

            return ret;
        }

        public async Task<int> ValidarProcessoParaIndicar(int idProcesso)
        {
            string comandoSql = string.Format(@"SELECT * FROM Processos
                                                where Status = 'Em Aberto' AND id = {0}",
                                                idProcesso);

            var ret = await _sqlHelper.ExecutarComando<Processo>(comandoSql);

            return ret.Count();
        }
    }
}