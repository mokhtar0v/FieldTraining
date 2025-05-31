using Microsoft.AspNetCore.Mvc;

namespace HireSphere.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
