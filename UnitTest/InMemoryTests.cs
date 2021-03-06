using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PirateApp.Data;
using PirateApp.Domain;

namespace EntityFramework_UnitTest
{
    [TestClass]
    public class InMemoryTests
    {

        [TestMethod]
        public void CanInsertIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("CanInsertPirate");

            using (var context = new PirateContext(builder.Options))
            {
                var pirate = new Pirate();

                context.Pirates.Add(pirate);

                context.SaveChanges();

                Assert.AreNotEqual(0, pirate.Id);
                Assert.AreEqual(EntityState.Added, context.Entry(pirate).State);
            }


        }
    }
}
