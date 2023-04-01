using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if(job == null)
            {
                return null;
            }
            var jobResponseModel = new JobResponseModel
            {
                Id = job.Id,
                Title = job.Title,
                StartDate = job.StartDate.GetValueOrDefault(),
                Description = job.Description
            };
            return jobResponseModel;
            
        }
        public async Task<int> AddJob(JobRequestModel model)
        {
            //call the repository that will use EF Core to save the data
            var jobEntity = new Job
            {
                Title= model.Title,
                StartDate= model.StartDate, 
                Description= model.Description,
                CreatedOn = DateTime.UtcNow,
                NumberOfPositions= model.NumberOfPositions,
                JobStatusLookUpId = 1
            };
            //we just created a job entity based on the model
            //and pass the entity to the database
            //The entity did not include the Id(PK)
            //But that's fine, the db will auto assign a PK to this entity
            //Each time the Add method is called, the PK will increase by one
            //the id wil be included in the returned entity(the entity object is changed reflecting the change in the db)
            //entity.Id now equals to the id assigned by the db
            var job = await _jobRepository.AddtAsync(jobEntity);
            return job.Id;
        }
    }
}
