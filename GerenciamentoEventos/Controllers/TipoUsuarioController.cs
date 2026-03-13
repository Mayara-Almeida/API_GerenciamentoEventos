using GerenciamentoEventos.Applications.Services;
using GerenciamentoEventos.DTOs.TipoUsuarioDto;
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

            }
        }
    }
}
