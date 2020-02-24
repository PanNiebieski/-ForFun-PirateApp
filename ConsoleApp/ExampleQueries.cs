using Microsoft.EntityFrameworkCore;
using PirateApp.Data;
using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework_ConsoleApp
{
    public class ExampleQueries
    {
        private static PirateContext _context = new PirateContext();


        private static void InsertNewSamuraiWithAQuote()
        {
            var pirate = new Pirate
            {
                Name = "Kambei Shimada",
                Sayings = new List<Saying>
        {
          new Saying { Text = "I've come to save you" }
        }
            };
            _context.Pirates.Add(pirate);
            _context.SaveChanges();
        }
        private static void InsertNewSamuraiWithManyQuotes()
        {
            var pirate = new Pirate
            {
                Name = "Kyūzō",
                Sayings = new List<Saying> {
            new Saying {Text = "Watch out for my sharp sword!"},
            new Saying {Text="I told you to watch out for the sharp sword! Oh well!" }
        }
            };
            _context.Pirates.Add(pirate);
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Pirates.FirstOrDefault();
            samurai.Sayings.Add(new Saying
            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiNotTracked(int pirateId)
        {
            var pirate = _context.Pirates.Find(pirateId);
            pirate.Sayings.Add(new Saying
            {
                Text = "Now that I saved you, will you feed me dinner?"
            });
            using (var newContext = new PirateContext())
            {
                newContext.Pirates.Attach(pirate);
                newContext.SaveChanges();
            }
        }
        private static void AddQuoteToExistingSamuraiNotTracked_Easy(int samuraiId)
        {
            var quote = new Saying
            {
                Text = "Now that I saved you, will you feed me dinner again?",
                PirateId = samuraiId
            };
            using (var newContext = new PirateContext())
            {
                newContext.Sayings.Add(quote);
                newContext.SaveChanges();
            }
        }
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Pirates.Where(s => s.Name.Contains("Julie"))
                                                     .Include(s => s.Sayings)
                                                     .Include(s => s.Crew)
                                                     .FirstOrDefault();
        }
        private static void ProjectSomeProperties()
        {
            var someProperties = _context.Pirates.Select(s => new { s.Id, s.Name }).ToList();
            var idsAndNames = _context.Pirates.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
        public struct IdAndName
        {
            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id;
            public string Name;
        }
        private static void ProjectSamuraisWithQuotes()
        {
            //var somePropertiesWithQuotes = _context.Samurais
            //   .Select(s => new { s.Id, s.Name, s.Quotes.Count })
            //   .ToList();
            //var somePropertiesWithQuotes = _context.Samurais
            //   .Select(s => new { s.Id, s.Name,
            //     HappyQuotes=s.Quotes.Where(q=>q.Text.Contains("happy")) })
            //   .ToList();
            var samuraisWithHappyQuotes = _context.Pirates
               .Select(s => new
               {
                   Samurai = s,
                   HappyQuotes = s.Sayings.Where(q => q.Text.Contains("happy"))
               })
               .ToList();
        }
        private static void FilteringWithRelatedData()
        {
            var samurais = _context.Pirates
                                   .Where(s => s.Sayings.Any(q => q.Text.Contains("happy")))
                                   .ToList();
        }
        private static void ModifyingRelatedDataWhenTracked()
        {
            var samurai = _context.Pirates.Include(s => s.Sayings).FirstOrDefault(s => s.Id == 2);
            samurai.Sayings[0].Text = " Did you hear that?";
            _context.Sayings.Remove(samurai.Sayings[2]);
            _context.SaveChanges();
        }
        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Pirates.Include(s => s.Sayings).FirstOrDefault(s => s.Id == 2);
            var quote = samurai.Sayings[0];
            quote.Text = "Did you hear that again?";
            using (var newContext = new PirateContext())
            {
                //newContext.Quotes.Update(quote);
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }
        private static void JoinBattleAndSamurai()
        {
            //Samurai and Battle already exist and we have their IDs
            var sbJoin = new PirateDuel { PirateId = 2, DuelId = 1 };
            _context.Add(sbJoin);
            _context.SaveChanges();
        }
        private static void EnlistSamuraiIntoABattle()
        {
            var duel = _context.Duel.Find(1);
            duel.PirtateDuels
                .Add(new PirateDuel { PirateId = 21 });
            _context.SaveChanges();

        }
        private static void GetSamuraiWithBattles()
        {
            var samuraiWithBattle = _context.Pirates
              .Include(s => s.PirateDuels)
              .ThenInclude(sb => sb.Duel)
              .FirstOrDefault(samurai => samurai.Id == 2);

            var samuraiWithBattlesCleaner = _context.Pirates.Where(s => s.Id == 2)
              .Select(s => new
              {
                  Samurai = s,
                  Battles = s.PirateDuels.Select(sb => sb.Duel)
              })
              .FirstOrDefault();
        }
        private static void RemoveJoinBetweenSamuraiAndBattleSimple()
        {
            var join = new PirateDuel { DuelId = 1, PirateId = 2 };
            _context.Remove(join);
            _context.SaveChanges();
        }
        private static void AddNewSamuraiWithHorse()
        {
            var pi = new Pirate { Name = "Jina Ujichika" };
            pi.Ship = new Ship { Name = "Silver" };
            _context.Pirates.Add(pi);
            _context.SaveChanges();
        }
        private static void AddNewHorseToSamuraiUsingId()
        {
            var shi = new Ship { Name = "Scout", Id = 2 };
            _context.Add(shi);
            _context.SaveChanges();
        }
        private static void AddNewHorseToSamuraiObject()
        {
            var pirate = _context.Pirates.Find(22);
            pirate.Ship = new Ship { Name = "Black Beauty" };
            _context.SaveChanges();
        }
        private static void AddNewHorseToDisconnectedSamuraiObject()
        {
            var samurai = _context.Pirates.AsNoTracking().FirstOrDefault(s => s.Id == 23);
            samurai.Ship = new Ship { Name = "Mr. Ed" };
            using (var newContext = new PirateContext())
            {
                newContext.Attach(samurai);
                newContext.SaveChanges();
            }
        }
        private static void ReplaceAHorse()
        {
            //var samurai = _context.Samurais.Include(s => s.Horse).FirstOrDefault(s => s.Id == 23);
            var pirate = _context.Ship.Find(23); //has a horse
            pirate = new Ship { Name = "Trigger" };
            _context.SaveChanges();
        }

        private static void GetSamuraisWithHorse()
        {
            var samurai = _context.Pirates.Include(s => s.Ship).ToList();

        }
        private static void GetHorseWithSamurai()
        {
            var horseWithoutSamurai = _context.Set<Ship>().Find(3);

            var horseWithSamurai = _context.Pirates.Include(s => s.Ship)
              .FirstOrDefault(s => s.Ship.Id == 3);

            var horsesWithSamurais = _context.Pirates
              .Where(s => s.Ship != null)
              .Select(s => new { Horse = s.Ship, Samurai = s })
              .ToList();

        }

    }
}
