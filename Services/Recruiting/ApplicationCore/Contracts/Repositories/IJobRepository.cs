using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IJobRepository
    {
        Task <List<Job>> GetAllJobs();

        Task <Job> GetJobByID(int id);
    }
}
