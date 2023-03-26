using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace RecruitingWeb.Controllers
{
    public class JobsController : Controller
    {
        
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }


        //http://example.com/jobs/index
        //hosted this webapp on the server, Azure-windows, azure linux
        //U1 -> http://example.com/jobs/index
        //U2, U3, U4...
        //10:00 AM 300 users accessing your website, 200 are accessing index methods
        [HttpGet] //attributes in C#
        public async Task <IActionResult> Index()
        {
            //we need to get list of Jobs
            //call the Job Service
            //var jobService = new JobService();


            //ASP.NET will assign a thread from threadpool(collection of threads) to do this task
            //T1 - T100 threads


            //database
            //I/O bound => go to this url and fetch me some data/image network, file download
            //database calls(I/O bound)
            //CPU bound => loan calculation, large Pi number, resizing processing


            //I/O bound, time is not constant
            //network, location, database disk SSD/HDD, SQL slow/fast, might be not optimized
            //waiting
            //prevent thread starvation

            //3 ways we can send data from controller / action method to view
            //1.ViewBag
            //2.ViewData
            //most frequently used way:
            //3. * **Strongly Typed Model data***
            ViewBag.PageTitle = "Showing Jobs";
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
            //thread starvation, scalability of our application
        }

        [HttpGet]
        public async Task <IActionResult> Details(int id)
        {
            //var jobService = new JobService();
            
            var job = await _jobService.GetJobById(id);
            return View(job);
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
