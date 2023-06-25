using Microsoft.AspNetCore.Mvc;

namespace NibulonTask.Controllers
{
    public class TableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
