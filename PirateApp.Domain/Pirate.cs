using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PirateApp.Domain
{

    public class Pirate
    {

        public Pirate()
        {

            Sayings = new List<Saying>();
            PirateDuels = new List<PirateDuel>();
        }

        public int Id { get; set; }


        public string Name { get; set; }

        public List<Saying> Sayings { get; set; }

        public Crew Crew { get; set; }

        public Ship Ship { get; set; }


        public List<PirateDuel> PirateDuels { get; set; }




    }
}
