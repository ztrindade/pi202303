using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Util.Interfaces;

namespace API_Indicacao_Premiada.Repositories
{
    public class ProcessoRepositorie : IProcessoRepositorie
    {
        private readonly IDBManager _sqlHelper;

        public ProcessoRepositorie(IDBManager sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public int IncluirProcesso(DTOIncluirProcesso processo)
        {
            string comandoSql = string.Format(@"INSERT INTO Processos (Empresa,Vaga,MatriculaRH,Status,ValorPremiacao)
                                                Values('{0}','{1}','{2}','Em Aberto',{3})",
                                                processo.Empresa, processo.Vaga, processo.MatriculaRH, processo.ValorPremiacao);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Processo> ListarProcessos()
        {
            string comandoSql = "SELECT * FROM Processos";

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Processo>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public IEnumerable<Processo> ListarProcessosEmAberto()
        {
            string comandoSql = "SELECT * FROM Processos where Status = 'Em Aberto'";

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando<Processo>(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }

        public int FinalizarProcesso(int id)
        {
            string comandoSql = string.Format("UPDATE Processos SET Status = 'Finalizado' where id = {0}", id);

            _sqlHelper.AbrirConexao();
            var ret = _sqlHelper.ExecutarComando(comandoSql);
            _sqlHelper.FecharConexao();

            return ret;
        }
    }
}