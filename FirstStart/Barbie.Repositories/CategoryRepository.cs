using Barbie.Core;
using Barbie.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbie.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public void AddCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public IEnumerable<Category> AllCategories()
        {
            return context.Categories.ToList();
        }

        public void DeleteCategory(int id)
        {
            context.Remove(GetCategoryById(id));
            context.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.Include(c => c.Barbies).FirstOrDefault(i => i.Id == id);
        }

        public void UpdateCategory(int id, Category model)
        {
            var category = GetCategoryById(id);
            if (category.CategoryName != model.CategoryName)
            {
                category.CategoryName = model.CategoryName;
            }

            context.Update(category);
            context.SaveChanges();
        }
    }
}
