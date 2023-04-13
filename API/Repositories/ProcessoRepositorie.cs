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

        public async Task<int> IncluirProcesso(DTOIncluirProcesso processo)
        {
            string comandoSql = string.Format(@"INSERT INTO Processos (Empresa,Vaga,MatriculaRH,Status,ValorPremiacao)
                                                Values('{0}','{1}','{2}','Em Aberto',{3})",
                                                processo.Empresa, processo.Vaga, processo.MatriculaRH, processo.ValorPremiacao);

            await _sqlHelper.AbrirConexao();
            var ret = await _sqlHelper.ExecutarComando(comandoSql);
            await _sqlHelper.FecharConexao();

            return ret;
        }

        public async Task<IEnumerable<Processo>> ListarProcessos()
        {
            string comandoSql = "SELECT * FROM Processos";

            await _sqlHelper.AbrirConexao();
            var ret = await _sqlHelper.ExecutarComando<Processo>(comandoSql);
            await _sqlHelper.FecharConexao();

            return ret;
        }

        public async Task<IEnumerable<Processo>> ListarProcessosEmAberto()
        {
            string comandoSql = "SELECT * FROM Processos where Status = 'Em Aberto'";

            await _sqlHelper.AbrirConexao();
            var ret = await _sqlHelper.ExecutarComando<Processo>(comandoSql);
            await _sqlHelper.FecharConexao();

            return ret;
        }

        public async Task<int> FinalizarProcesso(int id)
        {
            string comandoSql = string.Format("UPDATE Processos SET Status = 'Finalizado' where id = {0}", id);

            await _sqlHelper.AbrirConexao();
            var ret = await _sqlHelper.ExecutarComando(comandoSql);
            await _sqlHelper.FecharConexao();

            return ret;
        }
    }
}