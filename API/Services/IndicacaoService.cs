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

        public int IncluirIndicacao(DTOIncluirIndicacao indicacao)
        {
            var retValidacao = ValidarProcessoParaIndicar(indicacao.IdProcesso);
            if (retValidacao == 0)
                throw new InvalidDataException("Processo já finalizado");

            return _indicacaoRepositorie.IncluirIndicacao(indicacao);
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

        public int ValidarProcessoParaIndicar(int idProcesso)
        {
            return _indicacaoRepositorie.ValidarProcessoParaIndicar(idProcesso);
        }
    }
}