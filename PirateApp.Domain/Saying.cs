using System;
using System.Collections.Generic;
using System.Text;

namespace PirateApp.Domain
{
    public class Saying
    {

        public int Id { get; set; }

        public string Text { get; set; }

        public Pirate Pirate { get; set; }

        public int PirateId { get; set; }
    }
}
