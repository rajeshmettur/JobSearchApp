using JobSearchApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository.IRepository
{
    public interface IJobRepository : IRepository<JobEntity>
    {
        IEnumerable<SelectListItem> GetJobLists();
        void Update(JobEntity job);
    }
}
