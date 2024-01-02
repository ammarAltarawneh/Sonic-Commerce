using Microsoft.AspNetCore.Mvc;

namespace MyMarket.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
