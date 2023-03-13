using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IIndicacaoService
    {
        int IncluirIndicacao(DTOIncluirIndicacao dtoIncluirIndicacao);

        IEnumerable<Indicacao> ListarIndicacoes();

        int FinalizarIndicacao(int id);

        IEnumerable<Indicacao> ListarIndicacoesPorProcesso(int idProcesso);

        int FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao);

    }
}