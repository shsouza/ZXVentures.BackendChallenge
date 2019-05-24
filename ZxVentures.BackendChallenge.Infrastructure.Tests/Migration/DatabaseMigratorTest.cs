using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZxVentures.BackendChallenge.Infrastructure.Data;
using ZXVentures.BackendChallenge.Infrastructure.Migration;

namespace ZXVentures.BackendChallenge.Infrastructure.Tests.Migration
{
    [TestClass]
    public class DatabaseMigratorTest
    {
        [TestMethod]
        public void Migrate()
        {
            var context = new DatabaseContext();
        }
    }
}
