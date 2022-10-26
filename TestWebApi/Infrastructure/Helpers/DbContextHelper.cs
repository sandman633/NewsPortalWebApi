using Microsoft.EntityFrameworkCore;
using Model;


namespace TestWebApi.Infrastructure.Helpers
{
    public class DbContextHelper
    {
        public WebApiContext WebApiContext { get; set; }
        public DbContextHelper()
        {
            var builder = new DbContextOptionsBuilder<WebApiContext>();
            builder.UseInMemoryDatabase("UNIT_TEST_DB");

            var options = builder.Options;
            WebApiContext = new WebApiContext(options);
        }
    }
}
