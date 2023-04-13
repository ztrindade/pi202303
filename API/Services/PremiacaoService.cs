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

        public async Task<int> IncluirPremiacao(DTOFinalizarProcesso processoComDadosPremiacao)
        {
            var retValidacaoPremiacao = await ValidarPremiacaoParaIncluir(processoComDadosPremiacao.IdProcesso);
            if (retValidacaoPremiacao != 0)
                throw new InvalidDataException("Já existe uma premiação para o processo informado.");

            return await _premiacaoRepositorie.IncluirPremiacao(processoComDadosPremiacao);
        }

        public async Task<IEnumerable<Premiacao>> ListarPremiacoes()
        {
            return await _premiacaoRepositorie.ListarPremiacoes();
        }

        public async Task<IEnumerable<Premiacao>> ListarPremiacoesPorMatricula(string matricula)
        {
            return await _premiacaoRepositorie.ListarPremiacoesPorMatricula(matricula);
        }

        public async Task<int> ValidarPremiacaoParaIncluir(int idProcesso)
        {
            return await _premiacaoRepositorie.ValidarPremiacaoParaIncluir(idProcesso);
        }
    }
}