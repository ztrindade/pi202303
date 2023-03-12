using API_Indicacao_Premiada.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Indicacao_Premiada.Controllers
{
    [ApiController]
    [Route("premiacoes")]
    public class PremiacaoController : ControllerBase
    {
        private readonly IPremiacaoService _premiacaoService;

        public PremiacaoController(IPremiacaoService premiacaoService)
        {
            _premiacaoService = premiacaoService;
        }

        [HttpGet]
        [Route("listar/pormatricula/{matricula}")]
        public IActionResult ListarPremiacoesPorMatricula(string matricula)
        {
            try
            {
                var ret = _premiacaoService.ListarPremiacoesPorMatricula(matricula);
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarPremiacoes()
        {
            try
            {
                var ret = _premiacaoService.ListarPremiacoes();
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }
    }
}