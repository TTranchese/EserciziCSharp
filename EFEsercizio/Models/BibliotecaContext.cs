using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFEsercizio.Models;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Libri> Libris { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-BKL8UFN;Initial Catalog=Biblioteca;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Libri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libri__3213E83FC50BF540");

            entity.ToTable("Libri");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Anno).HasColumnName("anno");
            entity.Property(e => e.Autore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autore");
            entity.Property(e => e.Editore)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("editore");
            entity.Property(e => e.Piano).HasColumnName("piano");
            entity.Property(e => e.Scaffale).HasColumnName("scaffale");
            entity.Property(e => e.Titolo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titolo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
