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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {


                string connectionString = @"Data Source=CEZMSI\SQLEXPRESS;
                            Initial Catalog=PirateAppData;
                            Integrated Security=True;Pooling=False";

                optionsBuilder.UseSqlServer(connectionString, option => option.MaxBatchSize(150)).UseLoggerFactory(ConsoleLoggerFactory);
                ;
            }

            //base.OnConfiguring(optionsBuilder);
        }

        public static readonly ILoggerFactory ConsoleLoggerFactory = LoggerFactory.Create(builder =>

            {
                builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
                .AddConsole();

            });


        public PirateContext()
        {

        }

        public PirateContext(DbContextOptions option) : base(option)
        {

        }
    }

    public class PirateTestContext : PirateContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            string connectionString = @"Data Source=CEZMSI\SQLEXPRESS;
                    Initial Catalog=PirateAppTestData;
                    Integrated Security=True;Pooling=False";

            optionsBuilder.UseSqlServer(connectionString, option => option.MaxBatchSize(150)).UseLoggerFactory(ConsoleLoggerFactory);
            ;

        }
    }

}
