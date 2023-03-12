using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IPremiacaoService
    {
        int IncluirPremiacao(DTOFinalizarProcesso processo);

        IEnumerable<Premiacao> ListarPremiacoes();
        IEnumerable<Premiacao> ListarPremiacoesPorMatricula(string matricula);
    }
}