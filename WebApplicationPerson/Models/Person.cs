using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace WebApplicationPerson.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PFRStorage> PFRStorages { get; set; }
        public ApplicationContext()
        {
            //Database.EnsureDeleted();  
            Database.EnsureCreated();   
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DBPerson;Username=postgres;Password=solnce-2");
        }
    }
    public class Person
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateBirth {get; set;}
        public string Snils { get; set; }

    }

    public class PFRStorage
    {
        public int Id { get; set; }
        public string SnilsPFR { get; set; }
        public decimal Summa { get; set; }

        public string Period { get; set; }
    }

    public class PFRSumm
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Snils { get; set; }
        public decimal Summa { get; set; }
        public string Period { get; set; }
        public int Counter { get; set; }
    }
}
