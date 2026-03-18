using GerenciamentoEventos.Contexts;
using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.Especialidade;
using GerenciamentoEventos.Interfaces;

namespace GerenciamentoEventos.Repositores
{
    public class EspecialidadeRepository :IEspecialidadeRepository
    {
        private readonly GerenciamentoEventosContext _context;

        public EspecialidadeRepository(GerenciamentoEventosContext context)
        {
            _context = context;
        }

        public List<Especialidade> Listar()
        {
            return _context.Especialidade.ToList();
        }

        public Especialidade ObterPorId(int id)
        {
            Especialidade especialidade = _context.Especialidade.FirstOrDefault(e => e.EspecialidadeID == id);

            return especialidade;
        }

        public Especialidade ObterPorNome(string nomeEspecialidade)
        {
            Especialidade especialidade = _context.Especialidade.FirstOrDefault(e => e.NomeEspecialidade == nomeEspecialidade);

            return especialidade;
        }

        public bool EspecialidadeExiste(string nomeEspecialidade, int? especialidadeIDAtual = null)
        {
            var consultaBanco = _context.Especialidade.AsQueryable();

            if(especialidadeIDAtual.HasValue)
            {
                consultaBanco = consultaBanco.Where(especialidade => especialidade.EspecialidadeID != especialidadeIDAtual.Value);
            }

            return consultaBanco.Any(e => e.NomeEspecialidade == nomeEspecialidade);
        }

        public void Adicionar(Especialidade especialidade)
        {
            _context.Especialidade.Add(especialidade);
            _context.SaveChanges();
        }

        public void Atualizar(Especialidade especialidade)
        {
            Especialidade especialidadeBanco = _context.Especialidade.FirstOrDefault(e => e.EspecialidadeID == especialidade.EspecialidadeID);

            if(especialidadeBanco == null)
            {
                return;
            }

            especialidadeBanco.NomeEspecialidade = especialidade.NomeEspecialidade;
            _context.SaveChanges();
        }

        public void Remover(int id)
        {
            Especialidade especialidadeBanco = _context.Especialidade.FirstOrDefault(e => e.EspecialidadeID == id);


            if (especialidadeBanco == null)
            {
                return;
            }

            _context.Especialidade.Remove(especialidadeBanco);
            _context.SaveChanges();
        }
    }
}
