using Barbie.Core;
using Barbie.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Barbie.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepo;

        public CategoryController(CategoryRepository categoryR)
        {
            categoryRepo = categoryR;
        }

        public IActionResult Index()
        {
            var categories = categoryRepo.AllCategories();
            return View(categories);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.AddCategory(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = categoryRepo.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                categoryRepo.UpdateCategory(model.Id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = categoryRepo.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            var category = categoryRepo.GetCategoryById(id);
            if (category == null)
                return NotFound();

            if (category.Barbies == null || category.Barbies.Count() == 0)
            {
                categoryRepo.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            return View("Delete", category);
        }
    }
}
