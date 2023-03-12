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

        public int IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao)
        {
            string comandoSql = string.Format("INSERT INTO Premiacoes (IdProcesso,IdIndicacao,ValorPremiacao) Values('{0}','{1}',{2})",
                processoComDadosPremiacao.IdProcesso, processoComDadosPremiacao.IdIndicacao,processoComDadosPremiacao.ValorPremiacao);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Premiacao> ListarPremiacoes()
        {
            string comandoSql = "SELECT * FROM Premiacoes";

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Premiacao>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Premiacao> ListarPremiacoesPorMatricula(string matricula)
        {
            string comandoSql = string.Format(@"SELECT Premiacoes.Id,IdProcesso,IdIndicacao,Processos.ValorPremiacao 
                                                FROM Premiacoes
                                                JOIN Processos on 
                                                Premiacoes.IdProcesso = Processos.Id
                                                where MatriculaRH = '{0}'", matricula);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Premiacao>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }
    }
}