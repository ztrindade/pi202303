using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Entitys;
using API_Indicacao_Premiada.Repositories.Interfaces;
using API_Indicacao_Premiada.Services.Interfaces;

namespace API_Premiacao_Premiada.Services
{
    public class PremiacaoService : IPremiacaoService
    {
        private readonly IPremiacaoRepositorie _premiacaoRepositorie;

        public PremiacaoService(IPremiacaoRepositorie PremiacaoRepositorie)
        {
            _premiacaoRepositorie = PremiacaoRepositorie;
        }

        public int IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao)
        {
            var retValidacaoPremiacao = ValidarPremiacaoParaIncluir(processoComDadosPremiacao.IdProcesso);
            if (retValidacaoPremiacao != 0)
                throw new InvalidDataException("Já existe uma premiação para o processo informado.");
            
            return _premiacaoRepositorie.IncluirPremiacao(processoComDadosPremiacao);
        }

        public IEnumerable<Premiacao> ListarPremiacoes()
        {
            return _premiacaoRepositorie.ListarPremiacoes();
        }

        public IEnumerable<Premiacao> ListarPremiacoesPorMatricula(string matricula)
        {
            return _premiacaoRepositorie.ListarPremiacoesPorMatricula(matricula);
        }

        public int ValidarPremiacaoParaIncluir(int idProcesso)
        {
            return _premiacaoRepositorie.ValidarPremiacaoParaIncluir(idProcesso);
        }
    }
}