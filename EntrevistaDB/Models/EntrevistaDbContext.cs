using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntrevistaDB.Models;

public partial class EntrevistaDbContext : DbContext
{
    public EntrevistaDbContext()
    {
    }

    public EntrevistaDbContext(DbContextOptions<EntrevistaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=entrevistas.database.windows.net;Database=EntrevistaDB;User ID=Administrador;Password=Gus0328@;Encrypt=True;TrustServerCertificate=False;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClDni).HasName("PK__Clientes__369DC4084DF0C1D1");

            entity.Property(e => e.ClDni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cl_dni");
            entity.Property(e => e.ClApellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cl_apellidos");
            entity.Property(e => e.ClCelular)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cl_celular");
            entity.Property(e => e.ClCorreo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cl_correo");
            entity.Property(e => e.ClNombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cl_nombres");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.DvId).HasName("PK__DetalleV__AB8AFF833B471188");

            entity.Property(e => e.DvId).HasColumnName("dv_Id");
            entity.Property(e => e.DvCantidad).HasColumnName("dv_cantidad");
            entity.Property(e => e.DvPreciounitario)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dv_preciounitario");
            entity.Property(e => e.DvSubtotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("dv_subtotal");
            entity.Property(e => e.ProId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pro_id");
            entity.Property(e => e.VentaId).HasColumnName("venta_id");

            entity.HasOne(d => d.Pro).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK__DetalleVe__pro_i__18EBB532");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__DetalleVe__venta__17F790F9");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Producto__335E4CA6F1E540A3");

            entity.Property(e => e.ProId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pro_id");
            entity.Property(e => e.ProNombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pro_nombre");
            entity.Property(e => e.ProPrecio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("pro_precio");
            entity.Property(e => e.ProStock).HasColumnName("pro_stock");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__B1350809039296A3");

            entity.Property(e => e.VentaId).HasColumnName("venta_id");
            entity.Property(e => e.ClDni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cl_dni");
            entity.Property(e => e.VentaFecha).HasColumnName("venta_fecha");
            entity.Property(e => e.VentaImporteTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("venta_importeTotal");

            entity.HasOne(d => d.ClDniNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClDni)
                .HasConstraintName("FK__Ventas__cl_dni__14270015");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
