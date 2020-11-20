using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PirateApp.Domain;
using System;

namespace PirateApp.Data
{
    public class PirateContext : DbContext
    {
        public DbSet<Pirate> Pirates { get; set; }
        public DbSet<Saying> Sayings { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<Ship> Ship { get; set; }

        public DbSet<Duel> Duel { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = @"Data Source=CEZMSI\SQLEXPRESS;
                            Initial Catalog=PirateAppData;
                            Integrated Security=True;Pooling=False";


                optionsBuilder.UseSqlServer(connectionString,
                    option => option.MaxBatchSize(150)).
                    UseLoggerFactory(ConsoleLoggerFactory);
                
            }


        }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>

            {
                builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
                .AddConsole();

            });


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tabela nie ma kluczu głównego
            modelBuilder.Entity<PirateDuel>().HasKey(s => new { s.PirateId, s.DuelId });

            //modelBuilder.Entity<PirateDuel>().ToTable("PirateBattle");


            //modelBuilder.Entity<Pirate>().Property(p => p.Name)
            //    .HasColumnName("Namues")
            //    .HasColumnType("DateTime");



        }

        public PirateContext()
        {

        }

        public PirateContext(DbContextOptions option) : base(option)
        {

        }
    }



}
