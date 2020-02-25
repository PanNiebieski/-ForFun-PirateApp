using PirateApp.Data;
using PirateApp.Domain;
using System;
using System.Collections.Generic;

namespace PirateApp.BussinesLogic
{
    public interface IPirateService
    {
        IList<Pirate> GetAllPiratesWithData();

        bool AddPirate(Pirate pirate);
    }


}
