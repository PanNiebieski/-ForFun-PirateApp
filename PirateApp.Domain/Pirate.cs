using System;
using System.Collections.Generic;

namespace PirateApp.Domain
{
    public class Pirate
    {

        public Pirate()
        {
            List<Saying> Sayings = new List<Saying>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Saying> Sayings { get; set; }

        public Crew Clan { get; set; }

    }
}
