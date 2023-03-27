using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeapi.Data;
using testeapi.Models;

namespace testeapi.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        public ProductController(){
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {

            try
            {
                var products = await context.Product.ToListAsync();
                return products;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {

            try
            {
                var product = await context.Product.Include(x => x.Category)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if(product == null) throw new Exception("Nenhum registro encontrado.");
                return product;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("category/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategoryId([FromServices] DataContext context, int id)
        {

            try
            {
                var products = await context.Product
                    .Include(x => x.Category)
                    .AsNoTracking()
                    .Where(x => x.CategoryId == id)
                    .ToListAsync();
                if(products.Count == 0) throw new Exception("Nenhum registro encontrado.");
                return products;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromServices] DataContext context, [FromBody] Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Category = await context.Category
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == model.CategoryId);

                    context.Product.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}