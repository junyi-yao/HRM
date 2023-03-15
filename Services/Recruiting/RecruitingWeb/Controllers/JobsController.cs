using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        [HttpGet] //attributes in C#
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        //Authenticated and User should have role for creating new job
        //HR/Manager
        [HttpPost]
        public IActionResult Create()
        {
            //take the information from the view and save to DB
            return View();
        }
    }
}
