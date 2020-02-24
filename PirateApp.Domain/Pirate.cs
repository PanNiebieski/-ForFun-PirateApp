using System;
using System.Collections.Generic;

namespace PirateApp.Domain
{
    public class Pirate
    {

        public Pirate()
        {
            Sayings = new List<Saying>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Saying> Sayings { get; set; }

        public Crew Crew { get; set; }

        public Ship Ship { get; set; }

        public List<PirateDuel> PirateDuels { get; set; }

    }
}
