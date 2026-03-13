using System;
using System.Collections.Generic;

namespace GerenciamentoEventos.Domains;

public partial class Especialidade
{
    public int EspecialidadeID { get; set; }

    public string NomeEspecialidade { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
