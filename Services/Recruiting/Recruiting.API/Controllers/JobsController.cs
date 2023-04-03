using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    //attribute routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        //http://localhost/api/jobs ==> from the route for this class
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetALLJobs()
        {
            var jobs = await _jobService.GetAllJobs();


            if (!jobs.Any())
            {
                //no jobs exists, then 404
                return NotFound(new { error = "No open Jobs found, please try later" });
            }
            //return Json data, and also HTTP status codes
            //serialization C# objects into json Objects using System.Text.Json
            return Ok(jobs);

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetJobDetails")]
        public async Task<IActionResult> GetJobDetails(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new {errorMessage = "No Job found for this id"});
            }
            return Ok(job);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var job = await _jobService.AddJob(model);
            return CreatedAtAction
                ("GetJobDetails", new {controller = "Jobs", id = job}, "Job Created");
        }
    }
}
