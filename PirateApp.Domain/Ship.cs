using System;
using System.Collections.Generic;
using System.Text;

namespace PirateApp.Domain
{
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Power { get; set; }

        public int HowManyPeopleCanTake { get; set; }
    }
}
