using Microsoft.AspNetCore.Mvc;

namespace MediClinic_Project.Controllers
{
    public class loki : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
