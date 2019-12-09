using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class OpFlixContext : DbContext
    {
        public OpFlixContext()
        {
        }

        public OpFlixContext(DbContextOptions<OpFlixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Classificacao> Classificacao { get; set; }
        public virtual DbSet<FilmeSeries> FilmeSeries { get; set; }
        public virtual DbSet<Identificacao> Identificacao { get; set; }
        public virtual DbSet<Plataforma> Plataforma { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_OpFlix;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Classificacao>(entity =>
            {
                entity.HasKey(e => e.IdClassificacao);

                entity.HasIndex(e => e.Classificacao1)
                    .HasName("UQ__Classifi__AE2C4A0F933E5311")
                    .IsUnique();

                entity.Property(e => e.Classificacao1)
                    .IsRequired()
                    .HasColumnName("Classificacao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FilmeSeries>(entity =>
            {
                entity.HasKey(e => e.IdFs);

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__FilmeSer__7B406B56D549AF58")
                    .IsUnique();

                entity.Property(e => e.IdFs).HasColumnName("IdFS");

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Veiculo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.FilmeSeries)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__FilmeSeri__IdCat__19DFD96B");

                entity.HasOne(d => d.IdClassificacaoNavigation)
                    .WithMany(p => p.FilmeSeries)
                    .HasForeignKey(d => d.IdClassificacao)
                    .HasConstraintName("FK__FilmeSeri__IdCla__1BC821DD");

                entity.HasOne(d => d.IdIdentificacaoNavigation)
                    .WithMany(p => p.FilmeSeries)
                    .HasForeignKey(d => d.IdIdentificacao)
                    .HasConstraintName("FK__FilmeSeri__IdIde__1AD3FDA4");

                entity.HasOne(d => d.IdPlataformaNavigation)
                    .WithMany(p => p.FilmeSeries)
                    .HasForeignKey(d => d.IdPlataforma)
                    .HasConstraintName("FK__FilmeSeri__IdPla__1CBC4616");
            });

            modelBuilder.Entity<Identificacao>(entity =>
            {
                entity.HasKey(e => e.IdIdentificacao);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plataforma>(entity =>
            {
                entity.HasKey(e => e.IdPlataforma);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Platafor__7D8FE3B2E3E121E0")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__TipoUsua__8E762CB452BB3B87")
                    .IsUnique();

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534864AB89F")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuario__IdTipo__7D439ABD");
            });
        }
    }
}
