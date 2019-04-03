namespace WebApiParaiso.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelodb : DbContext
    {
        public Modelodb()
            : base("name=Modelodb")
        {
        }

        public DbSet<categorias> categorias { get; set; }
        public DbSet<cliente> cliente { get; set; }
        public DbSet<detallereservacion> detallereservacion { get; set; }
        public DbSet<orden> orden { get; set; }
        public DbSet<productos> productos { get; set; }
        public DbSet<reservacion> reservacion { get; set; }
        public DbSet<ubicacion> ubicacion { get; set; }
        public DbSet<usuapp> usuapp { get; set; }

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
                .HasMany(e => e.reservacion)
                .WithOptional(e => e.cliente)
                .HasForeignKey(e => e.idcliente);

            modelBuilder.Entity<productos>()
                .Property(e => e.nomproducto)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<productos>()
                .Property(e => e.precio)
                .HasPrecision(6, 2);

            modelBuilder.Entity<productos>()
                .HasMany(e => e.detallereservacion)
                .WithRequired(e => e.productos)
                .HasForeignKey(e => e.idproducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservacion>()
                .HasMany(e => e.detallereservacion)
                .WithRequired(e => e.reservacion)
                .HasForeignKey(e => e.idreservacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<reservacion>()
                .HasMany(e => e.orden)
                .WithOptional(e => e.reservacion)
                .HasForeignKey(e => e.idreservacion);

            modelBuilder.Entity<ubicacion>()
                .Property(e => e.nomubicacion)
                .IsUnicode(false);

            modelBuilder.Entity<ubicacion>()
                .HasMany(e => e.orden)
                .WithRequired(e => e.ubicacion)
                .HasForeignKey(e => e.idubicacion)
                .WillCascadeOnDelete(false);

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
        }
    }
}
