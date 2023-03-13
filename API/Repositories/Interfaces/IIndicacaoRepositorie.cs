using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IIndicacaoRepositorie
    {
        int IncluirIndicacao(DTOIncluirIndicacao Indicacao);

        IEnumerable<Indicacao> ListarIndicacoes();

        int FinalizarIndicacao(int id);

        IEnumerable<Indicacao> ListarIndicacoesPorProcesso(int idProcesso);

        int ValidarProcessoParaIndicar(int idProcesso);

        int FinalizarIndicacoesNaoEscolhidas(int idProcesso, int idIndicacao);
    }
}