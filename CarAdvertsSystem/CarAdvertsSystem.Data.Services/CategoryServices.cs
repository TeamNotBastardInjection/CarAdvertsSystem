using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using System.Linq;
using CarAdvertsSystem.Data.Services.Contracts;

namespace CarAdvertsSystem.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryServices(IRepository<Category> categoryRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(categoryRepository, "Category Repository is Null!!!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of Work is Null!!!").IsNull().Throw();

            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
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
