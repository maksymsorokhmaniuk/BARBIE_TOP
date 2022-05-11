using Barbie.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barbie.Repositories
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> AllCategories();
        public Category GetCategoryById(int id);
        public void AddCategory(Category category);
        public void DeleteCategory(int id);
        public void UpdateCategory(int id, Category model);
    }
}
