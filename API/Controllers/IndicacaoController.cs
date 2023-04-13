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
        public async Task<IActionResult> IncluirIndicacao([FromBody] DTOIncluirIndicacao indicacao)
        {
            if (indicacao == null)
            {
                return BadRequest();
            }

            try
            {
                await _indicacaoService.IncluirIndicacao(indicacao);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarIndicacoes()
        {
            try
            {
                var ret = await _indicacaoService.ListarIndicacoes();
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpGet]
        [Route("listar/porprocesso/{id}")]
        public async Task<IActionResult> ListarIndicacoesPorProcesso(int id)
        {
            try
            {
                var ret = await _indicacaoService.ListarIndicacoesPorProcesso(id);
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }
    }
}