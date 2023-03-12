using API_Indicacao_Premiada.DTO;
using API_Indicacao_Premiada.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Indicacao_Premiada.Controllers
{
    [ApiController]
    [Route("processos")]
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoService _processoService;

        public ProcessoController(IProcessoService processoService)
        {
            _processoService = processoService;
        }

        [HttpPost]
        [Route("incluir")]
        public IActionResult IncluirProcesso([FromBody] DTOIncluirProcesso processo)
        {
            if (processo == null)
            {
                return BadRequest();
            }

            _processoService.IncluirProcesso(processo);

            return Ok();
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarProcessos()
        {
            var ret = _processoService.ListarProcessos();

            return Ok(ret);
        }

        [HttpPost]
        [Route("finalizar")]
        public IActionResult FinalizarProcesso([FromBody] DTOFinalizarProcesso processo)
        {
            if (processo == null)
            {
                return BadRequest();
            }

            var ret = _processoService.FinalizarProcesso(processo);

            return Ok(ret);
        }
    }
}