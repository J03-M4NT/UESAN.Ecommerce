using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> CreateCategory(Category category);
        Task DeleteCategoryAsync(int id);
        Task DeleteCategorySoft(int id);
        IEnumerable<Category> GetAllCategories();
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> UpdateCategoryAsync(Category category);
    }

    // La interfaz ICategoryRepository define los métodos que se implementarán en la clase CategoryRepository.
    // Aquella que podria utilizar una capa siguiente, como la capa de servicios, para interactuar con la base de datos.
    // La interfaz vemos los titulos de los metodos, que vemos en el repositorio.

    // Para apps externas, es totalmente independiente como se ejecute, no va a saber como lo crea pero lo hara



}