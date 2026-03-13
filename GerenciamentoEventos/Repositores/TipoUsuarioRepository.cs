using GerenciamentoEventos.Contexts;
using GerenciamentoEventos.Domains;
using GerenciamentoEventos.Interfaces;

namespace GerenciamentoEventos.Repositores
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly GerenciamentoEventosContext _context;

        public TipoUsuarioRepository(GerenciamentoEventosContext context)
        {
            _context = context;
        }

        public List<TipoUsuario> Listar()
        {
            return _context.TipoUsuario.ToList();
        }

        public TipoUsuario ObterPorId(int id)
        {
            TipoUsuario tipoUsuario = _context.TipoUsuario.FirstOrDefault(u => u.TipoUsuarioID == id);

            return tipoUsuario;
        }
    }
}
