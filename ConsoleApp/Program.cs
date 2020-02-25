using Microsoft.EntityFrameworkCore;
using PirateApp.Data;
using PirateApp.Domain;
using System;
using System.Collections.Generic;
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
            //context.Database.EnsureCreated();


            //GetPirates("Before Add");
            //AddPirate();
            //GetPirates("After Add");


            ///AddShip();
            GetPiratesWithData();
            // GetFirstPirate();


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

        //Explicit Loading in Entity Framework
        //TRZY SELEKTY
        public static Pirate GetFirstPirate()
        {

            var pi = context.Pirates
                                .Where(s => s.Name == "Luffy")
                                .FirstOrDefault<Pirate>();

            context.Entry(pi).Reference(s => s.Ship).Load();
            context.Entry(pi).Collection(s => s.Sayings).Load();

            return pi;

        }

        //jeden SELEC Z LEFT JOIN
        public static IList<Pirate> GetPiratesWithData()
        {
            var pir = context.Pirates.Include(k => k.Sayings).
                Include(k => k.PirateDuels)
                .ThenInclude(a => a.Duel)

                .Include(k => k.Ship).Include(k => k.Crew);

            var r = pir.ToList();


            return r;

            //_context.Entry(pir).Collection(s => s.Sayings);
            //_context.Entry(pir).Reference(a => a.Ship);
        }

        public static void AddDuel()
        {
            var pir = context.Pirates.Include(k => k.PirateDuels).First();

            Duel duel = new Duel() { EndDate = DateTime.Now.AddDays(-4000), StartDate = DateTime.Now.AddDays(-4001), Name = "Bitwa pod Scharaką" };
            PirateDuel p = new PirateDuel() { Duel = duel, Pirate = pir };

            pir.PirateDuels.Add(p);

            context.Duel.Add(duel);
            context.Update(pir);
            context.SaveChanges();
        }

        public static void AddShip()
        {
            var pir = context.Pirates.Include(k => k.Ship).First();

            Ship s = new Ship();
            s.Name = "Albos II";
            s.Power = 4;
            s.HowManyPeopleCanTake = 40;

            pir.Ship = s;

            //using (var newContext = new PirateContext())
            //{
            //    newContext.Pirates.Attach(pir);
            //    newContext.SaveChanges();
            //}

            context.Update(pir);
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
