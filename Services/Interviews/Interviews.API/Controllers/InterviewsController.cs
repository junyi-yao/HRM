using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAllInterviews()
        {
            //go to database and get all the interviews based on role
            //if role is admin, get all
            //if role is manager, get only manager's interviews
            //read the header using HttpContext
            //JWT token
            //Authorization Header, Bearer Your_Token
            //userid, roles
            //decode the JWT to C# object

            var interviews = new List<String>(new[] {"abc, xyz, ddd","aasda"});
            return Ok(interviews);
        }
    }
}
