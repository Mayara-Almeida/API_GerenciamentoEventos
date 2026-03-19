using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.UsuarioDto;

namespace GerenciamentoEventos.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario ObterPorId(int id);
    }
}
