using Microsoft.EntityFrameworkCore;
using PirateApp.Data;
using PirateApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static PirateContext context = new PirateContext();

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="System.IO.IOException">Ignore.</exception>
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();

            GetPirates("Before Add");
            //AddPirate();
            GetPirates("After Add");
            Console.WriteLine("Press Any key...");
            Console.ReadKey();

        }

        private static void AddPirate()
        {
            var pirate = new Pirate() { Name = "Luffy" };
            pirate.Crew = new Crew() { CrewName = "Słomek" };
            pirate.Ship = new Ship() { Name = "Rakieta", Power = 2 };
            pirate.Sayings.Add(new Saying() { Text = "Zostane królem piratów" });


            context.Pirates.Add(pirate);
            context.SaveChanges();
        }


        private static void GetPirates(string text)
        {
            var pirates = context.Pirates.ToList();

            Console.WriteLine($"{text}: Pirate count is {pirates.Count}");

            foreach (var pirate in pirates)
            {
                Console.WriteLine(pirate.Name);
            }

            //var pir = context.Pirates.Include(k => k.Sayings).FirstOrDefault(s => s.Name.Contains("Luffy"));

            //context.Entry(pir).Collection(s => s.Sayings);
            //context.Entry(pir).Reference(a => a.Ship);
        }


    }
}
