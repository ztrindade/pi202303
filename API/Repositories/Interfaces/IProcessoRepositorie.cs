using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IProcessoRepositorie
    {
        int IncluirProcesso(DTOIncluirProcesso processo);

        IEnumerable<Processo> ListarProcessos();

        int FinalizarProcesso(int id);

        IEnumerable<Processo> ListarProcessosEmAberto();
    }
}