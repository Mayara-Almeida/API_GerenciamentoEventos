namespace GerenciamentoEventos.DTOs.UsuarioDto
{
    public class LerUsuarioDto
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        public int? EspecialidadeID { get; set; }

        public int? TipoUsuarioID { get; set; }
    }
}
