using ApplicationCore.Contracts.Repositories;
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
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<List<JobResponseModel>> GetAllJobs() {

            //var jobs = new List<JobResponseModel>() {
            //    new JobResponseModel{Id = 1, Title = ".NET Developer", Description = "Need to Know SQL and C#"},
            //    new JobResponseModel{Id = 2, Title = "Full Stack Developer", Description = "Need to Know C#"},
            //    new JobResponseModel{Id = 3, Title = "Java Developer", Description = "Need to Know JAVA"},
            //    new JobResponseModel{Id = 4, Title = "JavaScript Developer", Description = "Need to Know Javascript"}
            //};
            var jobs = await _jobRepository.GetAllJobs();
            var jobResponseModel = new List<JobResponseModel>();
            foreach (var job in jobs)
            {
                jobResponseModel.Add(new JobResponseModel
                {
                    Id = job.Id, Description = job.Description, Title = job.Title, StartDate = job.StartDate.GetValueOrDefault() , NumberOfPositions = job.NumberOfPositions 
                });   
            }
            //or use LINQ approach
            //return jobs.Select(job => new JobResponseModel { Id = job.Id, Description = job.Description, Title= job.Title }).ToList();
            return jobResponseModel;
        }

        public async Task<JobResponseModel> GetJobById(int id) {
            var job = await _jobRepository.GetJobByID(id);
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description
            };
            return jobResponseModel;
            
        }
    }
}
