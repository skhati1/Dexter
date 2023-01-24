using Dexter.Models;
using Microsoft.EntityFrameworkCore;

namespace Dexter.Test
{
    public class DexterMockDatabase : IDisposable
    {
        public DexterDbContext context { get; private set; }

        public DexterMockDatabase()
        {
            var options = new DbContextOptionsBuilder<DexterDbContext>()
                .UseInMemoryDatabase("DexterDatabase" + DateTime.Now.ToFileTimeUtc())
                .Options;

            context = new DexterDbContext(options);

            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
