using GerenciamentoEventos.Applications.Services;
using GerenciamentoEventos.DTOs.TipoUsuarioDto;
using GerenciamentoEventos.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly TipoUsuarioService _service;

        public TipoUsuarioController(TipoUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerTipoUsuarioDto>> Listar()
        {
            List<LerTipoUsuarioDto> tipos = _service.Listar();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public ActionResult<LerTipoUsuarioDto?> ObterPorId(int id)
        {
            try
            {
                LerTipoUsuarioDto tipoUsuario = _service.ObterPorId(id);
                return Ok(tipoUsuario);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
