using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PirateApp.BussinesLogic
{
    public class PirateInMemeoryService : IPirateService
    {
        private List<Pirate> pirates = new List<Pirate>();

        public PirateInMemeoryService()
        {
            var pirate = new Pirate() { Name = "Luffy" };
            pirate.Crew = new Crew() { CrewName = "Słomek" };
            pirate.Ship = new Ship() { Name = "Rakieta", Power = 2 };
            pirate.Sayings.Add(new Saying() { Text = "Zostane królem piratów" });

            Duel duel = new Duel()
            { EndDate = DateTime.Now.AddDays(-4000), StartDate = DateTime.Now.AddDays(-4001), Name = "Bitwa pod Scharaką" };
            PirateDuel p = new PirateDuel() { Duel = duel, Pirate = pirate };

            pirate.PirateDuels.Add(p);



            pirates.Add(pirate);
        }

        public bool AddPirate(Pirate pirate)
        {
            pirates.Add(pirate);
            return true;
        }

        public IList<Pirate> GetAllPiratesWithData()
        {
            return pirates;
        }
    }
}
