using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.Especialidade;
using GerenciamentoEventos.Exceptions;
using GerenciamentoEventos.Interfaces;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

            List<LerEspecialidadeDto> especialidadeDto = especialidades.Select(especialidade => new LerEspecialidadeDto
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

        public LerEspecialidadeDto ObterPorNome(string nomeEspecialidade)
        {
            Especialidade especialidade = _repository.ObterPorNome(nomeEspecialidade);

            if (especialidade == null)
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

        private static void ValidarEspecialidade(string especialidade)
        {
            if (string.IsNullOrWhiteSpace(especialidade))
            {
                throw new DomainException("O nome da especialidade é obrigatório.");
            }
        }

        public void Adicionar(CriarEspecialidadeDto criarDto)
        {
            ValidarEspecialidade(criarDto.NomeEspecialidade);

            if(_repository.EspecialidadeExiste(criarDto.NomeEspecialidade))
            {
                throw new DomainException("Especialidade já existente.");
            }

            Especialidade especialidade = new Especialidade
            {
                NomeEspecialidade = criarDto.NomeEspecialidade
            };

            _repository.Adicionar(especialidade);
        }

        public void Atualizar(int id, CriarEspecialidadeDto criarDto)
        {
            ValidarEspecialidade(criarDto.NomeEspecialidade);

            Especialidade especialidadeBanco = _repository.ObterPorId(id);

            if(especialidadeBanco == null)
            {
                throw new DomainException("Especialidade não encontrada.");
            }

            if (_repository.EspecialidadeExiste(criarDto.NomeEspecialidade, especialidadeIDAtual : id))
            {
                throw new DomainException("Especialidade já existente.");
            }

            especialidadeBanco.NomeEspecialidade = criarDto.NomeEspecialidade;
            _repository.Atualizar(especialidadeBanco);
        }

        public void Remover(int id)
        {
            Especialidade especialidadeBanco = _repository.ObterPorId(id);

            if (especialidadeBanco == null)
            {
                throw new DomainException("Especialidade não encontrada.");
            }

            _repository.Remover(id);
        }
    }
}
