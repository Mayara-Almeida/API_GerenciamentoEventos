using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.TipoUsuarioDto;
using GerenciamentoEventos.Exceptions;
using GerenciamentoEventos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEventos.Applications.Services
{
    public class TipoUsuarioService
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioService(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }

        public List<LerTipoUsuarioDto> Listar()
        {
            List<TipoUsuario> tipos = _repository.Listar();

            List<LerTipoUsuarioDto> tipo = tipos.Select(tipo => new LerTipoUsuarioDto
            {
                TipoUsuarioID = tipo.TipoUsuarioID,
                Tipo = tipo.Tipo
            }).ToList();

            return tipo;
        }

        public LerTipoUsuarioDto ObterPorId(int id)
        {
            TipoUsuario tipoUsuario = _repository.ObterPorId(id);

            if(tipoUsuario == null)
            {
                throw new DomainException("Tipo de usuário não encontrado.");
            }

            LerTipoUsuarioDto tipoUsuarioDto = new LerTipoUsuarioDto
            {
                TipoUsuarioID = tipoUsuario.TipoUsuarioID,
                Tipo = tipoUsuario.Tipo
            };

            return tipoUsuarioDto;
        }
    }
}
