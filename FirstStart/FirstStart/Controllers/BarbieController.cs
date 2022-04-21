using Barbie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstStart.Controllers

{
    public class BarbieController : Controller
    {
        private readonly IAllBarbie _allBarbie;
        private readonly IBarbieCategory _allCategories;

        public BarbieController(IAllBarbie iAllBarbie, IBarbieCategory iBarbieCategory)
        {
            _allBarbie = iAllBarbie;
            _allCategories = iBarbieCategory;
        }
        public IActionResult List()
        {
            var barbie = _allBarbie.Barbies;
            return View(barbie);
        }
    }
}
