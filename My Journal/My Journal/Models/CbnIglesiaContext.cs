﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using My_Journal.Models;
using My_Journal.Models.Divisa;
using My_Journal.Models.EgresosVarios;
using My_Journal.Models.IngresosVarios;
using My_Journal.Models.Miembros;
using My_Journal.Models.Ofrenda;
using My_Journal.Models.OfrendaCategoria;
using My_Journal.Models.Pagos;
using My_Journal.Models.PagosCategoria;
using My_Journal.Models.Usuario;
using My_Journal.Models.EgresosCategoria;
namespace My_Journal;

public partial class CbnIglesiaContext : DbContext
{
    public CbnIglesiaContext()
    {
    }

    public CbnIglesiaContext(DbContextOptions<CbnIglesiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OfrendasCategoria> OfrendasCategorias { get; set; }

    public virtual DbSet<Divisa> Divisas { get; set; }

    public virtual DbSet<EgresosVario> EgresosVarios { get; set; }

    public virtual DbSet<Iglesium> Iglesia { get; set; }

    public virtual DbSet<IngresosVario> IngresosVarios { get; set; }

    public virtual DbSet<EgresoCategoria> EgresosCategorias { get; set; }
    public virtual DbSet<Miembro> Miembros { get; set; }

    public virtual DbSet<Ofrenda> Ofrendas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PagosCategoria> PagosCategorias { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=CBN_IGLESIA;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EgresoCategoria>(entity =>
        {
            entity.HasKey(e => e.IdCatEgreso).HasName("PK__EgresosCategoria__IdCatEgreso");

            entity.ToTable("EgresosCategoria", "IGLESIA"); // Asegúrate que el esquema y nombre coincidan con tu tabla real

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(500);

            entity.Property(e => e.Estado);

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");

        });


        modelBuilder.Entity<OfrendasCategoria>(entity =>
        {
            entity.HasKey(e => e.IdCatOfrenda).HasName("PK__OfrendasCategoria__3BB07412B1FBF2D1");

            entity.ToTable("OfrendasCategoria", "ADM");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.OfrendasCategorias)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__Diezmo__UsuarioC__4222D4EF");
        });

        //modelBuilder.Entity<Diezmo>(entity =>
        //{
        //    entity.HasKey(e => e.IdDiezmo).HasName("PK__Diezmo__3BB07412B1FBF2D1");

        //    entity.ToTable("Diezmo", "IGLESIA");

        //    entity.Property(e => e.Descripcion).HasMaxLength(200);
        //    entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        //    entity.Property(e => e.FechaDiezmo).HasColumnType("datetime");
        //    entity.Property(e => e.FechaModifica).HasColumnType("datetime");

        //    entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Diezmos)
        //        .HasForeignKey(d => d.UsuarioCreacion)
        //        .HasConstraintName("FK__Diezmo__UsuarioC__4222D4EF");
        //});

        
        modelBuilder.Entity<Divisa>(entity =>
        {
            entity.HasKey(e => e.IdDivisa).HasName("PK__Divisas__DA960DCB2A730F13");

            entity.ToTable("Divisas", "ADM");

            entity.Property(e => e.CodDivisa).HasMaxLength(20);
            entity.Property(e => e.Descripcion).HasMaxLength(20);
            entity.Property(e => e.Simbolo).HasMaxLength(5);
        });

        modelBuilder.Entity<EgresosVario>(entity =>
        {
            entity.HasKey(e => e.IdEgreVarios).HasName("PK__EgresosV__2FC8D0E0771E5250");

            entity.ToTable("EgresosVarios", "IGLESIA");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaEgreso).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
        });

        modelBuilder.Entity<Iglesium>(entity =>
        {
            entity.HasKey(e => e.IdIglesia).HasName("PK__Iglesia__5D353C1A1B8E5D40");

            entity.ToTable("Iglesia", "ADM");

            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.Esquema).HasMaxLength(20);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<IngresosVario>(entity =>
        {
            entity.HasKey(e => e.IdIngreVarios).HasName("PK__Ingresos__0413C7C5F4E5D459");

            entity.ToTable("IngresosVarios", "IGLESIA");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.IngresosVarios)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__IngresosV__Usuar__4D94879B");
        });


        modelBuilder.Entity<Miembro>(entity =>
        {
            entity.HasKey(e => e.IdMiembro).HasName("PK__Miembros__7B9226C8D765AD4D");

            entity.ToTable("Miembros", "IGLESIA");

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.FechaBautismo).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Miembros)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__Miembros__Usuari__3F466844");
        });

        modelBuilder.Entity<Ofrenda>(entity =>
        {
            entity.HasKey(e => e.IdOfrenda).HasName("PK__Ofrendas__252FE8A595EF4A3E");

            entity.ToTable("Ofrendas", "IGLESIA");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Ofrenda)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__Ofrendas__Usuari__59063A47");
        });

        //modelBuilder.Entity<OfrendasCategoria>(entity =>
        //{
        //    entity.HasKey(e => e.IdCatOfrenda).HasName("PK__Ofrendas__A053EF0856DEF2C8");

        //    entity.ToTable("OfrendasCategoria", "IGLESIA");

        //    entity.Property(e => e.Descripcion).HasMaxLength(200);
        //    entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        //    entity.Property(e => e.FechaModifica).HasColumnType("datetime");
        //    entity.Property(e => e.Nombre).HasMaxLength(50);

        //    entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.OfrendasCategoria)
        //        .HasForeignKey(d => d.UsuarioCreacion)
        //        .HasConstraintName("FK__OfrendasC__Usuar__5629CD9C");
        //});

       
        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__Pagos__FC851A3A7B6919AF");

            entity.ToTable("Pagos", "IGLESIA");

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.FechaPago).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__Pagos__UsuarioCr__66603565");
        });

        modelBuilder.Entity<PagosCategoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__PagosCat__A3C02A101A9211F0");

            entity.ToTable("PagosCategorias", "IGLESIA");

            entity.Property(e => e.Descripcion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.UsuarioCreacionNavigation).WithMany(p => p.PagosCategoria)
                .HasForeignKey(d => d.UsuarioCreacion)
                .HasConstraintName("FK__PagosCate__Usuar__6383C8BA");
        });

        
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__2A49584C6251E999");

            entity.ToTable("Roles", "ADM");

            entity.Property(e => e.CodRol).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF97068BE899");

            entity.ToTable("Usuarios", "ADM");

            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Clave).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
