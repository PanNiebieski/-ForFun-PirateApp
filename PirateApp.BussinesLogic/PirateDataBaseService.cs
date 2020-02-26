using Microsoft.EntityFrameworkCore;
using PirateApp.Data;
using PirateApp.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PirateApp.BussinesLogic
{
    public class PirateDataBaseService : IPirateService
    {
        private PirateContext _context = new PirateContext();

        public PirateDataBaseService()
        {

        }

        public bool AddPirate(Pirate pirate)
        {
            _context.Pirates.Add(pirate);

            foreach (var item in pirate.PirateDuels)
            {
                _context.Duel.Add(item.Duel);
            }

            _context.SaveChanges();
            return true;
        }

        public IList<Pirate> GetAllPiratesWithData()
        {
            var pir = _context.Pirates.Include(k => k.Sayings).
                Include(k => k.PirateDuels).
                ThenInclude(p => p.Duel).
                Include(k => k.Ship).Include(k => k.Crew);

            var r = pir.ToList();


            return r;

        }

        public async Task<IList<Pirate>> GetAllPiratesWithDataAsync()
        {
            var pir = _context.Pirates.Include(k => k.Sayings).
                Include(k => k.PirateDuels).
                ThenInclude(p => p.Duel).
                Include(k => k.Ship).Include(k => k.Crew);

            var r = pir.ToListAsync();


            return await r;

        }

        public void GetFirstPirate()
        {

            var pi = _context.Pirates
                                .Where(s => s.Name == "Luffy")
                                .FirstOrDefault<Pirate>();

            _context.Entry(pi).Reference(s => s.Ship).Load(); // loads StudentAddress
            _context.Entry(pi).Collection(s => s.Sayings).Load(); // loads Courses collection

        }


    }
}