using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.Especialidade;
using GerenciamentoEventos.Exceptions;
using GerenciamentoEventos.Interfaces;

namespace GerenciamentoEventos.Applications.Services
{
    public class EspecialidadeService
    {
        private readonly IEspecialidadeRepository _repository;

        public EspecialidadeService (IEspecialidadeRepository repository)
        {
            _repository = repository;
        }

        public List<LerEspecialidadeDto> Listar()
        {
            List<Especialidade> especialidades = _repository.Listar();

            List<LerEspecialidadeDto> especialidadeDto = especialidades.Select(especialidade => new LerEspecialidadeDto(
            {
                EspecialidadeID = especialidade.EspecialidadeID,
                NomeEspecialidade = especialidade.NomeEspecialidade
            }).ToList();

            return especialidadeDto;
        }

        public LerEspecialidadeDto ObterPorId(int id)
        {
            Especialidade especialidade = _repository.ObterPorId(id);

            if(especialidade == null)
            {
                throw new DomainException("Especialidade não encontrada.");
            }

            LerEspecialidadeDto especialidadeDto = new LerEspecialidadeDto
            {
                EspecialidadeID = especialidade.EspecialidadeID,
                NomeEspecialidade = especialidade.NomeEspecialidade
            };

            return especialidadeDto;
        }

        public void Adicionar(CriarEspecialidadeDto criarDto)
        {

        }
    }
}
