using Application.Data.Context;
using Application.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get([FromServices] ApplicationContext applicationContext)
        {
            return applicationContext.Products.AsNoTracking().ToList();
        }
    }
}