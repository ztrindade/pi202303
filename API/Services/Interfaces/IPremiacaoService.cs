using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IPremiacaoService
    {
        Task<int> IncluirPremiacao(DTOFinalizarProcesso processo);

        Task<IEnumerable<Premiacao>> ListarPremiacoes();

        Task<IEnumerable<Premiacao>> ListarPremiacoesPorMatricula(string matricula);
    }
}