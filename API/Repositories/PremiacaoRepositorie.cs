using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Util.Interfaces;

namespace API_Indicacao_Premiada.Repositories
{
    public class PremiacaoRepositorie : IPremiacaoRepositorie
    {
        private readonly IDBManager _sqlHelper;

        public PremiacaoRepositorie(IDBManager sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public async Task<int> IncluirPremiacao(DTOIncluirPremiacao processoComDadosPremiacao)
        {
            string comandoSql = string.Concat("INSERT INTO Premiacoes (IdProcesso,IdIndicacao,ValorPremiacao) Values(@Idprocesso,@IdIndicacao,@ValorPremiacao)");

            var parametros = new
            {
                Idprocesso = processoComDadosPremiacao.IdProcesso,
                IdIndicacao = processoComDadosPremiacao.IdIndicacao,
                ValorPremiacao = processoComDadosPremiacao.ValorPremiacao
            };

            var ret = await _sqlHelper.ExecutarComando(comandoSql,parametros);

            return ret;
        }

        public async Task<IEnumerable<Premiacao>> ListarPremiacoes()
        {
            string comandoSql = "SELECT * FROM Premiacoes";

            var ret = await _sqlHelper.ExecutarComando<Premiacao>(comandoSql);

            return ret;
        }

        public async Task<IEnumerable<Premiacao>> ListarPremiacoesPorMatricula(string matricula)
        {
            string comandoSql = string.Format(@"SELECT Premiacoes.Id,Premiacoes.IdProcesso,Premiacoes.IdIndicacao,Premiacoes.ValorPremiacao
                                                FROM Premiacoes
                                                JOIN Indicacoes on
                                                Premiacoes.IdIndicacao = Indicacoes.Id
                                                where MatriculaIndicante = '{0}'", matricula);

            var ret = await _sqlHelper.ExecutarComando<Premiacao>(comandoSql);

            return ret;
        }

        public async Task<int> ValidarPremiacaoParaIncluir(int idProcesso)
        {
            string comandoSql = String.Format("SELECT * FROM Premiacoes where IdProcesso = {0}", idProcesso);
            var ret = await _sqlHelper.ExecutarComando<Premiacao>(comandoSql);

            return ret.Count();
        }

        public async Task<decimal> ObterValorPremicao(int idProcesso)
        {
            string comandoSql = String.Format("SELECT ValorPremiacao FROM Processos where Id = {0}", idProcesso);
            var ret = await _sqlHelper.ExecutarComando<decimal>(comandoSql);

            return ret.FirstOrDefault();
        }
    }
}