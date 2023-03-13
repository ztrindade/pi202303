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

            try
            {
                _processoService.IncluirProcesso(processo);
                return Ok();
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListarProcessos()
        {
            try
            {
                var ret = _processoService.ListarProcessos();
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpGet]
        [Route("listar/iniciados")]
        public IActionResult ListarProcessosEmAberto()
        {
            try
            {
                var ret = _processoService.ListarProcessosEmAberto();
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro interno servidor");
            }
        }

        [HttpPost]
        [Route("finalizar")]
        public IActionResult FinalizarProcesso([FromBody] DTOFinalizarProcesso processo)
        {
            if (processo == null)
            {
                return BadRequest();
            }

            try
            {
                var ret = _processoService.FinalizarProcesso(processo);
                return Ok(ret);
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
    }
}