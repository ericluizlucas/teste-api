using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeapi.Data;
using testeapi.Models;

namespace testeapi.Controllers
{
    [ApiController]
    [Route("category")]
    public class CategoryController : ControllerBase
    {
        public CategoryController(){

        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {

            try
            {
                var categories = await context.Category.ToListAsync();
                return categories;
            }
            catch (System.Exception ex)
            {
                return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromServices] DataContext context, [FromBody] Category model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Category.Add(model);
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
                return ResponseHelper.Error(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}