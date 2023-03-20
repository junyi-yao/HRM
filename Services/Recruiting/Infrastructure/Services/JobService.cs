using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JobService:IJobService
    {
        public List<JobResponseModel> GetAllJobs() {

            var jobs = new List<JobResponseModel>() {
                new JobResponseModel{Id = 1, Title = ".NET Developer", Description = "Need to Know SQL and C#"},
                new JobResponseModel{Id = 2, Title = "Full Stack Developer", Description = "Need to Know C#"},
                new JobResponseModel{Id = 3, Title = "Java Developer", Description = "Need to Know JAVA"},
                new JobResponseModel{Id = 4, Title = "JavaScript Developer", Description = "Need to Know Javascript"}
            };
            return jobs;
        }

        public JobResponseModel GetJobById(int id) {
            return new JobResponseModel { Id = 4, Title = "Javascript Dev", Description = "Need to know JAVA"};
        }
    }
}
