using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Services.Interfaces;

namespace API_Premiacao_Premiada.Services
{
    public class PremiacaoService : IPremiacaoService
    {
        private readonly IPremiacaoRepositorie _PremiacaoRepositorie;

        public PremiacaoService(IPremiacaoRepositorie PremiacaoRepositorie)
        {
            _PremiacaoRepositorie = PremiacaoRepositorie;
        }

        public int IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao)
        {
            return _PremiacaoRepositorie.IncluirPremiacao(processoComDadosPremiacao);
        }

        public IEnumerable<Premiacao> ListarPremiacoes()
        {
            return _PremiacaoRepositorie.ListarPremiacoes();
        }
    }
}