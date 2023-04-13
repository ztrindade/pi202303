using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IPremiacaoRepositorie
    {
        Task<int> IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao);

        Task<IEnumerable<Premiacao>> ListarPremiacoes();

        Task<IEnumerable<Premiacao>> ListarPremiacoesPorMatricula(string matricula);

        Task<int> ValidarPremiacaoParaIncluir(int idProcesso);
    }
}