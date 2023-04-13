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

        public async Task<int> IncluirIndicacao(DTOIncluirIndicacao indicacao)
        {
            var retValidacao = await ValidarProcessoParaIndicar(indicacao.IdProcesso);
            if (retValidacao == 0)
                throw new InvalidDataException("Processo já finalizado");

            return await _indicacaoRepositorie.IncluirIndicacao(indicacao);
        }

        public async Task<IEnumerable<Indicacao>> ListarIndicacoes()
        {
            return await _indicacaoRepositorie.ListarIndicacoes();
        }

        public async Task<IEnumerable<Indicacao>> ListarIndicacoesPorProcesso(int idProcesso)
        {
            return await _indicacaoRepositorie.ListarIndicacoesPorProcesso(idProcesso);
        }

        public async Task<int> FinalizarIndicacao(int id)
        {
            return await _indicacaoRepositorie.FinalizarIndicacao(id);
        }

        public async Task<int> ValidarProcessoParaIndicar(int idProcesso)
        {
            return await _indicacaoRepositorie.ValidarProcessoParaIndicar(idProcesso);
        }

        public async Task<int> FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao)
        {
            return await _indicacaoRepositorie.FinalizarIndicacoesNaoEscolhidas(idProcesso, idIndicacao);
        }
    }
}