﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PirateApp.Domain
{
    public class Duel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PirateDuel> PirtateDuels { get; set; }

    }
}
