using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace inventariosmvc.Models;

public partial class InventarioContext : DbContext
{
    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Marca> Marcas { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Productos");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdMarcaNavigation)
                .WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("Marcas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}