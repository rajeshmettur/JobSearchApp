using JobSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository.IRepository
{
    public interface IJobApplicationRepository : IRepository<JobApplication>
    {
        void Update(JobApplication jobapp);
    }
}
