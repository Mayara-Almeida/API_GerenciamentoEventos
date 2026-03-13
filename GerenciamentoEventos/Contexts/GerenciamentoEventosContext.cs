using System;
using System.Collections.Generic;
using GerenciamentoEventos.Domains;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEventos.Contexts;

public partial class GerenciamentoEventosContext : DbContext
{
    public GerenciamentoEventosContext()
    {
    }

    public GerenciamentoEventosContext(DbContextOptions<GerenciamentoEventosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Especialidade> Especialidade { get; set; }

    public virtual DbSet<Evento> Evento { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GerenciamentoEventos;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.EspecialidadeID).HasName("PK__Especial__8829C359C92C9808");

            entity.HasIndex(e => e.NomeEspecialidade, "UQ__Especial__D6E5EBAEE14DF987").IsUnique();

            entity.Property(e => e.NomeEspecialidade)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventoID).HasName("PK__Evento__1EEB59014D9B659B");

            entity.Property(e => e.LocalEvento).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(150);
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.TipoUsuarioID).HasName("PK__TipoUsua__7F22C702EAF208A0");

            entity.HasIndex(e => e.Tipo, "UQ__TipoUsua__8E762CB42EE39B7B").IsUnique();

            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioID).HasName("PK__Usuario__2B3DE798BE6207F3");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053426B4D054").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Senha).HasMaxLength(32);

            entity.HasOne(d => d.Especialidade).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.EspecialidadeID)
                .HasConstraintName("FK__Usuario__Especia__5165187F");

            entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.TipoUsuarioID)
                .HasConstraintName("FK__Usuario__TipoUsu__52593CB8");

            entity.HasMany(d => d.Evento).WithMany(p => p.Usuario)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioEvento",
                    r => r.HasOne<Evento>().WithMany()
                        .HasForeignKey("EventoID")
                        .HasConstraintName("FK_EventoID"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioID")
                        .HasConstraintName("FK_UsuarioID"),
                    j =>
                    {
                        j.HasKey("UsuarioID", "EventoID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
