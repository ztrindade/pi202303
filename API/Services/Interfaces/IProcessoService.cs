using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IProcessoService
    {
        Task<int> IncluirProcesso(DTOIncluirProcesso dtoIncluirProcesso);

        Task<IEnumerable<Processo>> ListarProcessos();

        Task<int> FinalizarProcesso(DTOFinalizarProcesso processo);

        Task<IEnumerable<Processo>> ListarProcessosEmAberto();
    }
}