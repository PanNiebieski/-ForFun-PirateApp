using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiratesGrid.ViewModel
{
    public class PirateViewModel
    {

        public PirateViewModel()
        {
            Duels = new List<Duel>();
        }

        public Pirate Pirate { get; set; }


        public List<Duel> Duels { get; set; }

        public bool AddPirateMode { get; set; }

        public int NumberOfQuotes { get; set; }


        public int NumberOfBattles { get; set; }

        public FormMode FormMode { get; set; }

    }

    public enum FormMode
    {
        AddNumberofQuotesAndBattles,
        AddPirate,
        End
    }
}
