using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IIndicacaoService
    {
        Task<int> IncluirIndicacao(DTOIncluirIndicacao dtoIncluirIndicacao);

        Task<IEnumerable<Indicacao>> ListarIndicacoes();

        Task<int> FinalizarIndicacao(int id);

        Task<IEnumerable<Indicacao>> ListarIndicacoesPorProcesso(int idProcesso);

        Task<int> FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao);
    }
}