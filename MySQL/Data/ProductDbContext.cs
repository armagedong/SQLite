using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MySQL.Data
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Object> Objects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Object>().HasData(GetObjects());
            base.OnModelCreating(modelBuilder);
        }
        private Product[] GetProducts()
        {
            return new Product[]
            {
                new Product{ Id = 1, Name="Помидор", Discription="Красный", Price=150, Unit=500},
                new Product{ Id = 2, Name="Баклажан", Discription="ЛадаСедан", Price=500, Unit=100},
                new Product{ Id = 3, Name="Огурец", Discription="Зеленый", Price=250, Unit=250},
            };
        }
        private Object[] GetObjects()
        {
            return new Object[]
            {
                new Object{ Id = 1, Name="Камень", Discription="Серый", Count=324, Unit=3},
                new Object{ Id = 2, Name="Листок", Discription="Зеленый", Count=23, Unit=3},
                new Object{ Id = 3, Name="Тимоха", Discription="Анпилогов", Count=1, Unit=1},
            };
        }
    }
}
