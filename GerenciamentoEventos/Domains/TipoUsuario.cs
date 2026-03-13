using System;
using System.Collections.Generic;

namespace GerenciamentoEventos.Domains;

public partial class TipoUsuario
{
    public int TipoUsuarioID { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
