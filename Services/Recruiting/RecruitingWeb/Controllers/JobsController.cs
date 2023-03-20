using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        
        private IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        [HttpGet] //attributes in C#
        public IActionResult Index()
        {
            //we need to get list of Jobs
            //call the Job Service
            //var jobService = new JobService();
            var jobs = _jobService.GetAllJobs();
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            //var jobService = new JobService();
            var job = _jobService.GetJobById(id);
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
