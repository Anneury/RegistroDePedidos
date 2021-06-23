using Microsoft.EntityFrameworkCore;
using RegistroDePedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePedidos.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data/Ordenes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Suplidores---------------------------------------------------------------------
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 1,
                Nombres = "Anneury Andrés Sosa Abreu"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 2,
                Nombres = "Monserrat Blasco"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 3,
                Nombres = "Guillem Moron"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 4,
                Nombres = "Carme Aznar"
            });

            modelBuilder.Entity<Suplidores>().HasData(new Suplidores
            {
                SuplidorId = 5,
                Nombres = "Andrea Costas"
            });

            //Productos----------------------------------------------------------------------
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Descripcion = "Pepsi",
                Costo = 20,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Descripcion = "Kola Real",
                Costo = 15,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Descripcion = "Pastelito",
                Costo = 20,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Descripcion = "Chokies",
                Costo = 25,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 5,
                Descripcion = "Jugo Petit",
                Costo = 30,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 6,
                Descripcion = "Café",
                Costo = 25,
                Inventario = 100
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 7,
                Descripcion = "Pan",
                Costo = 10,
                Inventario = 100
            });
        }
    }
}
