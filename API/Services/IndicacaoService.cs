using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Services.Interfaces;

namespace API_Indicacao_Premiada.Services
{
    public class IndicacaoService : IIndicacaoService
    {
        private readonly IIndicacaoRepositorie _indicacaoRepositorie;

        public IndicacaoService(IIndicacaoRepositorie IndicacaoRepositorie)
        {
            _indicacaoRepositorie = IndicacaoRepositorie;
        }

        public int IncluirIndicacao(DTOIncluirIndicacao Indicacao)
        {
            return _indicacaoRepositorie.IncluirIndicacao(Indicacao);
        }

        public IEnumerable<Indicacao> ListarIndicacoes()
        {
            return _indicacaoRepositorie.ListarIndicacoes();
        }

        public IEnumerable<Indicacao> ListarIndicacoesPorProcesso(int idProcesso)
        {
            return _indicacaoRepositorie.ListarIndicacoesPorProcesso(idProcesso);
        }

        public int FinalizarIndicacao(int id)
        {
            return _indicacaoRepositorie.FinalizarIndicacao(id);
        }
    }
}