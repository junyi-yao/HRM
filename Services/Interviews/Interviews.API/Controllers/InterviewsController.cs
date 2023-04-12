using Microsoft.AspNetCore.Authorization;
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
        [Authorize]//will do the filter:this.HttpContext.User.Identity.IsAuthenticated
        //if you are not authenticated, this method won't even be executed
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

            //if (this.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    //go to database and get the values
            //}

            var interviews = new List<String>(new[] {"abc, xyz, ddd","aasda"});
            return Ok(interviews);
        }
    }
}
