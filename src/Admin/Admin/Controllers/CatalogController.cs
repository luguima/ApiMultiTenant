using Admin.Data.Context;
using Admin.Domain.Model;
using Application.Data.Context;
using Application.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CatalogController( IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<Catalog> Get([FromServices] CatalogContext db)
        {
            return db.Catalogs.AsNoTracking().ToList();
        }

        [HttpPost]
        public bool CreateCatalog(Catalog catalog, [FromServices] CatalogContext db)
        {
            db.Catalogs.Add(catalog);
            db.SaveChanges();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var connectionString = _configuration.GetConnectionString("custom").Replace("_DATABASE_", catalog.Database);

            optionsBuilder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging();

            using var dbApp = new ApplicationContext(optionsBuilder.Options);

            dbApp.Database.EnsureDeleted();
            dbApp.Database.EnsureCreated();

            for (var i = 1; i <= 5; i++)
            {
                dbApp.Products.Add(new Product { Name = $"{catalog.Database} - Product {i}" });
            }

            dbApp.SaveChanges();

            return true;
        }
    }
}