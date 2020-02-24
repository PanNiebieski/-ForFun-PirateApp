using Microsoft.EntityFrameworkCore;
using PirateApp.Domain;
using System;

namespace PirateApp.Data
{
    public class PirateContext : DbContext
    {

        public DbSet<Pirate> Pirates { get; set; }
        public DbSet<Saying> Sayings { get; set; }

        public DbSet<Crew> Crews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            string connectionString = @"Data Source=CEZMSI\SQLEXPRESS;
                    Initial Catalog=PirateAppData;
                    Integrated Security=True;Pooling=False";

            optionsBuilder.UseSqlServer(connectionString);

            //base.OnConfiguring(optionsBuilder);
        }
    }
}
