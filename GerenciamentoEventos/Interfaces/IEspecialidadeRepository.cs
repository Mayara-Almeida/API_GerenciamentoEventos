using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.Especialidade;

namespace GerenciamentoEventos.Interfaces
{
    public interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        Especialidade ObterPorId(int id);

        Especialidade ObterPorNome(string nomeEspecialidade);

        bool EspecialidadeExiste (string nomeEspecialidade, int? especialidadeIDAtual = null);

        void Adicionar(Especialidade especialidade);

        void Atualizar(Especialidade especialidade);

        void Remover(int id);
    }
}
