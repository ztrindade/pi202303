using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Indicacao_Premiada.Controllers
{
    [ApiController]
    [Route("indicacoes")]
    public class IndicacaoController : ControllerBase
    {
        private readonly IIndicacaoService _indicacaoService;

        public IndicacaoController(IIndicacaoService indicacaoService)
        {
            _indicacaoService = indicacaoService;
        }

        [HttpPost]
        [Route("incluir")]
        public IActionResult IncluirIndicacao([FromBody] DTOIncluirIndicacao indicacao)
        {
            if (indicacao == null)
            {
                return BadRequest();
            }

            _indicacaoService.IncluirIndicacao(indicacao);

            return Ok();
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarIndicacoes()
        {
            var ret = _indicacaoService.ListarIndicacoes();

            return Ok(ret);
        }

        [HttpGet]
        [Route("listar/porprocesso/{id}")]
        public IActionResult ListarIndicacoesPorProcesso(int id)
        {
            var ret = _indicacaoService.ListarIndicacoesPorProcesso(id);

            return Ok(ret);
        }
    }
}