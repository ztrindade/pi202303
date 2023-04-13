using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Repositories.Interfaces
{
    public interface IProcessoRepositorie
    {
        Task<int> IncluirProcesso(DTOIncluirProcesso processo);

        Task<IEnumerable<Processo>> ListarProcessos();

        Task<int> FinalizarProcesso(int id);

        Task<IEnumerable<Processo>> ListarProcessosEmAberto();
    }
}