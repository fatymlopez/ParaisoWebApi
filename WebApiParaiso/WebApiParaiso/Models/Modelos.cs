namespace WebApiParaiso.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelos : DbContext
    {
        public Modelos()
            : base("name=Modelos")
        {
        }

        public DbSet<categorias> categorias { get; set; }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<menu> menu { get; set; }
        public DbSet<orden> orden { get; set; }
        public DbSet<productos> productos { get; set; }
        public DbSet<reservacion> reservacion { get; set; }
        public DbSet<ubicacion> ubicacion { get; set; }
        public DbSet<usuapp> usuapp { get; set; }
        public virtual DbSet<ventash> ventash { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categorias>()
                .Property(e => e.nomcategoria)
                .IsUnicode(false);

            modelBuilder.Entity<categorias>()
                .HasMany(e => e.productos)
                .WithRequired(e => e.categorias)
                .HasForeignKey(e => e.idcategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.nombrecl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.cellcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.emailcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .Property(e => e.passcl)
                .IsUnicode(false);

            modelBuilder.Entity<cliente>()
                .HasMany(e => e.orden)
                .WithRequired(e => e.cliente)
                .HasForeignKey(e => e.idcliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<menu>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<orden>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<orden>()
                .Property(e => e.total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<orden>()
                .HasMany(e => e.ventash)
                .WithRequired(e => e.orden)
                .HasForeignKey(e => e.idorden)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.nomproducto)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<productos>()
                .HasMany(e => e.menu)
                .WithRequired(e => e.productos)
                .HasForeignKey(e => e.idproducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservacion>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ubicacion>()
                .Property(e => e.nomubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.emailusu)
                .IsUnicode(false);

            modelBuilder.Entity<usuapp>()
                .Property(e => e.passusu)
                .IsUnicode(false);

            modelBuilder.Entity<ventash>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ventash>()
                .Property(e => e.total)
                .HasPrecision(19, 4);
        }
    }
}
