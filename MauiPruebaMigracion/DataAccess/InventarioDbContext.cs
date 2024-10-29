using MauiPruebaMigracion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Microsoft.IO.RecyclableMemoryStreamManager;

namespace MauiPruebaMigracion.DataAccess
{
    public class InventarioDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public InventarioDbContext()
        {
                
        }
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options) 
        {
                Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDb.DevolverRuta("venta.db")}";
            optionsBuilder.UseSqlite(conexionDb);
            //optionsBuilder.UseLazyLoadingProxies();

            Console.WriteLine($"Usando la base de datos en: {conexionDb}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            });

        }
    }
}
