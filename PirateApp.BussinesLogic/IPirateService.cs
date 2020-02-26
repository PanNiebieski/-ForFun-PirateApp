using PirateApp.Data;
using PirateApp.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PirateApp.BussinesLogic
{
    public interface IPirateService
    {
        IList<Pirate> GetAllPiratesWithData();

        Task<IList<Pirate>> GetAllPiratesWithDataAsync();

        bool AddPirate(Pirate pirate);
    }


}
