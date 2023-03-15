using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class CandidatesController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
