using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CashControl
{
    public class ApplicationContext: DbContext
    {
        private string _databasePath;

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<CreditOperation> CreditOperations { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Source> Sources { get; set; }

        public ApplicationContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency[]
                { 
                    new Currency { CurrencyId = Guid.NewGuid().ToString(), Title = "Рубль", Description = ""},
                    new Currency { CurrencyId = Guid.NewGuid().ToString(), Title = "Доллар", Description = ""},
                    new Currency { CurrencyId = Guid.NewGuid().ToString(), Title = "Евро", Description = ""},
                });
            modelBuilder.Entity<CreditOperation>();
            modelBuilder.Entity<Operation>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<Source>();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
