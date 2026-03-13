using System;
using System.Collections.Generic;

namespace GerenciamentoEventos.Domains;

public partial class Usuario
{
    public int UsuarioID { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] Senha { get; set; } = null!;

    public int? EspecialidadeID { get; set; }

    public int? TipoUsuarioID { get; set; }

    public virtual Especialidade? Especialidade { get; set; }

    public virtual TipoUsuario? TipoUsuario { get; set; }

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();
}
