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

        Task<Pirate> GetPirateDetailsAsync(int id);

        Pirate GetPirateDetails(int id);

        bool AddPirate(Pirate pirate);

        Task<int> AddPirateAsync(Pirate pirate);
        Task<int> UpdatePirateAsync(Pirate pirate);
    }


}
