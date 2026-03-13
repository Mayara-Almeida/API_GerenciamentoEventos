using System;
using System.Collections.Generic;

namespace GerenciamentoEventos.Domains;

public partial class Evento
{
    public int EventoID { get; set; }

    public string Nome { get; set; } = null!;

    public DateOnly DataEvento { get; set; }

    public string LocalEvento { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
