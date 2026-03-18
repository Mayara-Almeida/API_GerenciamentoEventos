using GerenciamentoEventos.Applications.Services;
using GerenciamentoEventos.DTOs.Especialidade;
using GerenciamentoEventos.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly EspecialidadeService _service;

        public EspecialidadeController(EspecialidadeService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<LerEspecialidadeDto>> Listar()
        {
            List<LerEspecialidadeDto> especialidades = _service.Listar();
            return especialidades;
        }

        [HttpGet("{id}")]
        public ActionResult<LerEspecialidadeDto> ObterPorId(int id)
        {
            try
            {
                LerEspecialidadeDto especialidade = _service.ObterPorId(id);
                return Ok(especialidade);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("nome/{nomeEspecialidade}")]
        public ActionResult<LerEspecialidadeDto> ObterPorNome(string nomeEspecialidade)
        {
            try
            {
                LerEspecialidadeDto especialidade = _service.ObterPorNome(nomeEspecialidade);
                return Ok(especialidade);
            }
            catch (DomainException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Adicionar(CriarEspecialidadeDto criarDto)
        {
            try
            {
                _service.Adicionar(criarDto);
                return StatusCode(201);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, CriarEspecialidadeDto criarDto)
        {
            try
            {
                _service.Atualizar(id, criarDto);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    
}
