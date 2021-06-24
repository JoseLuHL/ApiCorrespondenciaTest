using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models.Models
{
    public partial class ApiCorrespondenciaTest_dbContext : DbContext
    {
      
        public ApiCorrespondenciaTest_dbContext(DbContextOptions<ApiCorrespondenciaTest_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Correspondencia> Correspondencia { get; set; }
        public virtual DbSet<Destinatario> Destinatarios { get; set; }
        public virtual DbSet<Lookup> Lookups { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Modulo> Modulos { get; set; }
        public virtual DbSet<OpcionModulo> OpcionModulos { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Remitente> Remitentes { get; set; }
        public virtual DbSet<TipoLookup> TipoLookups { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<ViewDestinatario> ViewDestinatarios { get; set; }
        public virtual DbSet<ViewRemitente> ViewRemitentes { get; set; }
        public virtual DbSet<FMenuPadreVo> MenuPadre { get; set; }
        public virtual DbSet<FMenuHijoVo> MenuHijo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Correspondencia>(entity =>
            {
                entity.HasKey(e => e.IdCorrespondencia)
                    .HasName("Pk_Correspondencia_IdCorrespondencia");

                entity.HasIndex(e => e.IdTipoCorrespondencia, "Unq_Correspondencia_IdTipoCorrespondencia")
                    .IsUnique();

                entity.Property(e => e.IdCorrespondencia).HasMaxLength(20);

                entity.Property(e => e.ArchivoAdjunto).HasMaxLength(20);

                entity.Property(e => e.DireccionRemitente)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Telefono1Destinatario).HasMaxLength(10);

                entity.Property(e => e.Telefono1Remitente).HasMaxLength(10);

                entity.Property(e => e.Telefono2Destinatario).HasMaxLength(10);

                entity.Property(e => e.Telefono2Remitente).HasMaxLength(10);

                entity.HasOne(d => d.ObjIdDestinatario)
                    .WithMany(p => p.Correspondencia)
                    .HasForeignKey(d => d.IdDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Correspondencia_Destinatario1");

                entity.HasOne(d => d.ObjIdEstado)
                    .WithMany(p => p.CorrespondenciumIdEstadoNavigations)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Correspondencia_Lookups");

                entity.HasOne(d => d.ObjIdRemitente)
                    .WithMany(p => p.Correspondencia)
                    .HasForeignKey(d => d.IdRemitente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Correspondencia_Remitente");

                entity.HasOne(d => d.ObjIdTipoCorrespondencia)
                    .WithOne(p => p.CorrespondenciumIdTipoCorrespondenciaNavigation)
                    .HasForeignKey<Correspondencia>(d => d.IdTipoCorrespondencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Correspondencia_Lookups1");
            });

            modelBuilder.Entity<Destinatario>(entity =>
            {
                entity.HasKey(e => e.IdDestinatario);

                entity.ToTable("Destinatario");

                entity.Property(e => e.IdDestinatario).ValueGeneratedNever();

                entity.HasOne(d => d.ObjIdDestinatario)
                    .WithOne(p => p.Destinatario)
                    .HasForeignKey<Destinatario>(d => d.IdDestinatario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Destinatario_Persona");
            });

            modelBuilder.Entity<Lookup>(entity =>
            {
                entity.HasKey(e => e.IdLookup)
                    .HasName("Pk_Lookups_IdLookup_0");

                entity.Property(e => e.Codigo).HasMaxLength(5);

                entity.Property(e => e.Nombre).IsRequired();

                entity.HasOne(d => d.IdTipoLookupNavigation)
                    .WithMany(p => p.Lookups)
                    .HasForeignKey(d => d.IdTipoLookup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lookups_TipoLookup");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).ValueGeneratedNever();

                entity.HasOne(d => d.IdOpcionNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdOpcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_OpcionModulo");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Lookups");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.HasKey(e => e.IdModulo);

                entity.ToTable("Modulo");

                entity.Property(e => e.IdModulo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Imagen).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OpcionModulo>(entity =>
            {
                entity.HasKey(e => e.IdOpcion);

                entity.ToTable("OpcionModulo");

                entity.Property(e => e.IdOpcion).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Imagen).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ruta)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdModuloNavigation)
                    .WithMany(p => p.OpcionModulos)
                    .HasForeignKey(d => d.IdModulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OpcionModulo_Modulo");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Pk_Persona_IdPersona");

                entity.ToTable("Persona");

                entity.Property(e => e.Apellidos).HasMaxLength(70);

                entity.Property(e => e.Crreo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(60);

                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.HasOne(d => d.ObjIdTipoIdentificacion)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoIdentificacion)
                    .HasConstraintName("FK_Persona_Lookups");
            });

            modelBuilder.Entity<Remitente>(entity =>
            {
                entity.HasKey(e => e.IdRemitente);

                entity.ToTable("Remitente");

                entity.Property(e => e.IdRemitente).ValueGeneratedNever();

                entity.HasOne(d => d.IdRemitenteNavigation)
                    .WithOne(p => p.Remitente)
                    .HasForeignKey<Remitente>(d => d.IdRemitente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Remitente_Persona");
            });

            modelBuilder.Entity<TipoLookup>(entity =>
            {
                entity.HasKey(e => e.IdTipoLookup)
                    .HasName("Pk_Lookups_IdLookup");

                entity.ToTable("TipoLookup");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<ViewDestinatario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Destinatarios");

                entity.Property(e => e.Apellidos).HasMaxLength(70);

                entity.Property(e => e.Crreo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(60);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });

            modelBuilder.Entity<ViewRemitente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Remitente");

                entity.Property(e => e.Apellidos).HasMaxLength(70);

                entity.Property(e => e.Crreo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre).HasMaxLength(60);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
