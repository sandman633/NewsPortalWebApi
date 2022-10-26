using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model;

namespace TestWebApi.Infrastructure.Helpers.DbHelpers
{
    public class DbContextHelper
    {
        public WebApiContext WebApiContext { get; set; }
        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<WebApiContext>();
            builder.UseInMemoryDatabase("UNIT_TEST_DB").ConfigureWarnings(x=>x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            var options = builder.Options;
            WebApiContext = new WebApiContext(options);
            WebApiContext.Database.EnsureDeleted();
            WebApiContext.Database.EnsureCreated();

            WebApiContext.AddRange(UserHelper.GetMany());

            WebApiContext.SaveChanges();
        }
    }
}
