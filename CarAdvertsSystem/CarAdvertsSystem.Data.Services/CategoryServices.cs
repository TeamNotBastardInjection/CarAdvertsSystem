using Bytes2you.Validation;
using CarAdvertsSystem.Data.Contracts;
using CarAdvertsSystem.Data.Models;
using System.Linq;

namespace CarAdvertsSystem.Data.Services
{
    public class CategoryServices
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

        ///// <summary>
        ///// Creates new Category by name.
        ///// </summary>
        ///// <param name="name"></param>
        //public void Create(string name)
        //{
        //    Guard.WhenArgument(name, "Category to Add is Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        var category = new Category() { Name = name };

        //        this.categoryRepository.Add(category);

        //        unitOfWork.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// Update Category name by Id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="name"></param>
        //public void UpdateCategoryNameById(int id, string name)
        //{
        //    Guard.WhenArgument(name, "Category to Add is Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        this.categoryRepository.GetById(id).Name = name;

        //        unitOfWork.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// Delete categoy by Id
        ///// </summary>
        ///// <param name="id"></param>
        //public void DeleteById(int id)
        //{
        //    Guard.WhenArgument(id.ToString(), "The Id of the Advert cannot be Null!!!").IsNull().Throw();

        //    using (var unitOfWork = this.unitOfWork)
        //    {
        //        this.categoryRepository.Delete(id);

        //        this.unitOfWork.SaveChanges();
        //    }
        //}
    }
}
