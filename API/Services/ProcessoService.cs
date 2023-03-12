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

        public int IncluirProcesso(DTOIncluirProcesso processo)
        {
            return _processoRepositorie.IncluirProcesso(processo);
        }

        public IEnumerable<Processo> ListarProcessos()
        {
            return _processoRepositorie.ListarProcessos();
        }

        public IEnumerable<Processo> ListarProcessosEmAberto()
        {
            return _processoRepositorie.ListarProcessosEmAberto();
        }

        public int FinalizarProcesso(DTOFinalizarProcesso processo)
        {
            var retProcesso = _processoRepositorie.FinalizarProcesso(processo.IdProcesso);

            if (retProcesso != 0)
            {
                var retIndicacao = _indicacaoService.FinalizarIndicacao(processo.IdIndicacao);

                if (retIndicacao != 0)
                {
                    _premiacaoService.IncluirPremiacao(processo);
                }
            }

            return retProcesso;
        }
    }
}