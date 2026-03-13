using GerenciamentoEventos.Domains;
using GerenciamentoEventos.DTOs.TipoUsuarioDto;

namespace GerenciamentoEventos.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario ObterPorId(int id);
    }
}
