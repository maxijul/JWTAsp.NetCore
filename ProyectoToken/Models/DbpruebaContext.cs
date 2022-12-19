﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoToken.Models;

public partial class DbpruebaContext : DbContext
{
  public DbpruebaContext()
  {
  }

  public DbpruebaContext(DbContextOptions<DbpruebaContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Usuario> Usuarios { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Usuario>(entity =>
    {
      entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97D2C23312");

      entity.ToTable("Usuario");

      entity.Property(e => e.Clave)
              .HasMaxLength(20)
              .IsUnicode(false);
      entity.Property(e => e.NombreUsuario)
              .HasMaxLength(20)
              .IsUnicode(false);
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
