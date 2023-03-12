using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;

namespace API_Indicacao_Premiada.Services.Interfaces
{
    public interface IProcessoService
    {
        int IncluirProcesso(DTOIncluirProcesso dtoIncluirProcesso);

        IEnumerable<Processo> ListarProcessos();

        int FinalizarProcesso(DTOFinalizarProcesso processo);
    }
}