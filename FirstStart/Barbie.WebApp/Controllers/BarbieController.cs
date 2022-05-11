using Barbie.Core;
using Barbie.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstStart.Controllers
{
    public class BarbieController : Controller
    {
        private readonly IBarbieRepository barbieRepo;
        private readonly ICategoryRepository categoryRepo;
        private readonly IWebHostEnvironment environment;

        public BarbieController(BarbieRepository barbieR, CategoryRepository categoryR,
            IWebHostEnvironment envir)
        {
            barbieRepo = barbieR;
            categoryRepo = categoryR;
            environment = envir;
        }

        public IActionResult Index()
        {
            var barbies = barbieRepo.AllBarbies();
            return View(barbies);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Categories = categoryRepo.AllCategories();
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Barbiee model)
        {
            var category = categoryRepo.GetCategoryById(model.CategoryID);
            category.Barbies = category.Barbies ?? new List<Barbiee>();

            if (ModelState.IsValid)
            {
                var imgName = await UploadPhoto(model.ImgFile);
                var barbie = new Barbiee
                {
                    Name = model.Name,
                    Description = model.Description,
                    Img = imgName,
                    CategoryID = model.CategoryID,
                    Username = model.Username
                };

                barbieRepo.AddBarbie(barbie);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<string> UploadPhoto(IFormFile barbiePhoto)
        {
            if (barbiePhoto != null)
            {
                var splitName = barbiePhoto.FileName.Split('.');
                var extention = "." + splitName.Last();

                var fileName = Guid.NewGuid() + extention;
                var physicalPath = environment.WebRootPath + "/Imgs/" + fileName.ToString();

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    barbiePhoto.CopyTo(stream);
                }
                return fileName.ToString();
            }
            return "noPhoto.jpg";
        }

        [HttpGet]
        public IActionResult BarbiesInCategory(int id)
        {
            var barbies = barbieRepo.GetBarbiesByCategory(id);
            return View("Index", barbies);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            var barbie = barbieRepo.GetBarbieById(id);
            if (barbie == null)
                return NotFound();

            ViewBag.Categories = categoryRepo.AllCategories();
            return View(barbie);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(Barbiee model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImgFile != null)
                {
                    if (model.Img != "noPhoto.jpg")
                    {
                        var imagePath = environment.WebRootPath + "/Imgs/" + model.Img;
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                }
                var imgName = await UploadPhoto(model.ImgFile);
                var barbie = new Barbiee
                {
                    Name = model.Name,
                    Description = model.Description,
                    Img = imgName,
                    CategoryID = model.CategoryID,
                    Username = model.Username
                };

                barbieRepo.UpdateBarbie(model.Id, barbie);
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

            var barbie = barbieRepo.GetBarbieById(id);
            if (barbie == null)
                return NotFound();

            ViewBag.CategoryName = categoryRepo.GetCategoryById(barbie.CategoryID).CategoryName;
            return View(barbie);
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteBarbie(int id)
        {
            var barbie = barbieRepo.GetBarbieById(id);
            if (barbie == null)
                return NotFound();

            if (barbie.Img == "noPhoto.jpg")
            {
                barbieRepo.DeleteBarbie(id);
            }
            else
            {
                var imagePath = environment.WebRootPath + "/Imgs/" + barbie.Img;
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                barbieRepo.DeleteBarbie(id);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchText)
        {
            var found = barbieRepo.FindBarbie(searchText);
            return View("Index", found);
        }
    }
}
