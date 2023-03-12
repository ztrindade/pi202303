using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IPremiacaoRepositorie
    {
        int IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao);

        IEnumerable<Premiacao> ListarPremiacoes();

        IEnumerable<Premiacao> ListarPremiacoesPorMatricula(string matricula);
    }
}