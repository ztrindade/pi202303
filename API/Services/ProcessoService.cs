using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Services.Interfaces;

namespace API_Indicacao_Premiada.Services
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepositorie _processoRepositorie;
        private readonly IIndicacaoService _indicacaoService;
        private readonly IPremiacaoService _premiacaoService;

        public ProcessoService(IProcessoRepositorie processoRepositorie, IIndicacaoService indicacaoService, IPremiacaoService premiacaoService)
        {
            _processoRepositorie = processoRepositorie;
            _indicacaoService = indicacaoService;
            _premiacaoService = premiacaoService;
        }

        public async Task<int> IncluirProcesso(DTOIncluirProcesso processo)
        {
            return await _processoRepositorie.IncluirProcesso(processo);
        }

        public async Task<IEnumerable<Processo>> ListarProcessos()
        {
            return await _processoRepositorie.ListarProcessos();
        }

        public async Task<IEnumerable<Processo>> ListarProcessosEmAberto()
        {
            return await _processoRepositorie.ListarProcessosEmAberto();
        }

        public async Task<int> FinalizarProcesso(DTOFinalizarProcesso processo)
        {
            var retProcesso = await _processoRepositorie.FinalizarProcesso(processo.IdProcesso);

            if (retProcesso != 0)
            {
                var retIndicacao = await _indicacaoService.FinalizarIndicacao(processo.IdIndicacao);

                if (retIndicacao != 0)
                {
                    var retPremiacao = await _premiacaoService.IncluirPremiacao(processo);

                    if (retPremiacao != 0)
                        await _indicacaoService.FinalizarIndicacoesNaoEscolhidas(processo.IdProcesso, processo.IdIndicacao);
                }
            }

            return retProcesso;
        }
    }
}