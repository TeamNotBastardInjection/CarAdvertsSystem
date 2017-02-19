using System.Linq;

using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using CarAdvertsSystem.Data.Services.Contracts;

using Bytes2you.Validation;

namespace CarAdvertsSystem.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryServices(IRepository<Category> categoryRepository)
        {
            Guard.WhenArgument(categoryRepository, "Category Repository is Null!!!").IsNull().Throw();

            this.categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        public IQueryable<Category> GetAllCategories()
        {
            return this.categoryRepository.All();
        }

        /// <summary>
        /// Get category by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns category.</returns>
        public Category GetById(int id)
        {
            return this.categoryRepository.GetById(id);
        }
    }
}
