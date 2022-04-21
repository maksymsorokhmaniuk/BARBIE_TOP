using Barbie.Core;
using Barbie.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstStart.Controllers

{
    public class BarbieController : Controller
    {
        public IActionResult List()
        {           
            return View("List", new Barbiee { Name = "barbie 1"});
        }
    }
}
