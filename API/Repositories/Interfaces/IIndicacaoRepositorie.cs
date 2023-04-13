using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IIndicacaoRepositorie
    {
        Task<int> IncluirIndicacao(DTOIncluirIndicacao Indicacao);

        Task<IEnumerable<Indicacao>> ListarIndicacoes();

        Task<int> FinalizarIndicacao(int id);

        Task<IEnumerable<Indicacao>> ListarIndicacoesPorProcesso(int idProcesso);

        Task<int> ValidarProcessoParaIndicar(int idProcesso);

        Task<int> FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao);
    }
}