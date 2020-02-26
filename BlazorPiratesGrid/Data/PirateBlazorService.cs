using PirateApp.BussinesLogic;
using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPiratesGrid.Data
{
    public class PirateBlazorService
    {

        public Task<IList<Pirate>> GetPirates()
        {
            PirateDataBaseService s = new PirateDataBaseService();

            return s.GetAllPiratesWithDataAsync();


        }
    }
}
