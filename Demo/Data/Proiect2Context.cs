using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Demo.Models;
using System.Reflection.Emit;

namespace Demo.Data
{
    public class Proiect2Context : DbContext
    {
        public DbSet<Produse> Produse { get; set; }
        public DbSet<ProduseInCategorie> ProduseInCategorie { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Reducere> Reducere { get; set; }
        public DbSet<Produse> Producator { get; set; }


        public Proiect2Context(DbContextOptions<Proiect2Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // One to Many
            modelBuilder.Entity<Producator>()
                .HasMany(m1 => m1.Produse)
                .WithOne(m2 => m2.Producator);

            // One to One
            modelBuilder.Entity<Reducere>()
                .HasOne(m5 => m5.Produse)
                .WithOne(m6 => m6.Reducere)
                .HasForeignKey<Produse>(m7 => m7.ReducereId);
               
            // Many to Many
            // cheie compusa
            modelBuilder.Entity<ProduseInCategorie>()
                        .HasKey(mr => new { mr.ProduseId, mr.CategorieId });

            modelBuilder.Entity<ProduseInCategorie>()
                        .HasOne(mr => mr.Produse)
                        .WithMany(m3 => m3.ProduseInCategorie)
                        .HasForeignKey(mr => mr.ProduseId);

            modelBuilder.Entity<ProduseInCategorie>()
                        .HasOne(mr => mr.Categorie)
                        .WithMany(m4 => m4.ProduseInCategorie)
                        .HasForeignKey(mr => mr.CategorieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
