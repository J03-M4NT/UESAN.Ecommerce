using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Ecommerce.CORE.Core.Entities;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;

        
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await categoryRepository.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // Ejemplo:
            // GET: api/Categories/5
        [HttpGet("{id}")]     // Despues del } puedes agregar un /parametro2,3,etc

            // Este codigo es para obtener una categoria por id
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }



        // POST: api/Categories
        [HttpPost]

        public async Task<IActionResult> CreateCategory([FromBody] Category category)   //FromBody indica que el objeto se va a recibir en el cuerpo de la peticion
        {
            if (category == null)
            {
                return BadRequest("Category is null");
            }
            var newCategoryId = await categoryRepository.CreateCategory(category);  // Cuando es asincrono usa el await.
            //Return:
            return Ok(newCategoryId);
        }


        // PUT: api/Categories
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("Category is null or ID mismatch");
            }
            var updatedCategory = await categoryRepository.UpdateCategoryAsync(category);
            if (!updatedCategory)
            {
                return NotFound();
            }
            return Ok(updatedCategory);
        }


        // DELETE: api/Categories
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            await categoryRepository.DeleteCategoryAsync(id);
            return NoContent();
        }

    }
}
