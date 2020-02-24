using System;
using System.Collections.Generic;
using System.Text;

namespace PirateApp.Domain
{
    public class PirateDuel
    {
        public int PirateId { get; set; }
        public int DuelId { get; set; }
        public Pirate Pirate { get; set; }
        public Duel Duel { get; set; }
    }
}
