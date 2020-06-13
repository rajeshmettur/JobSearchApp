using JobSearchApp.DataAccess.Data;
using JobSearchApp.DataAccess.Repository.IRepository;
using JobSearchApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchApp.DataAccess.Repository
{
    public class JobRepository : Repository<JobEntity>, IJobRepository
    {
        protected readonly ApplicationDbContext _context;
        public JobRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }
        public IEnumerable<SelectListItem> GetJobLists()
        {
            return _context.Job.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString()
            });
        }

        public void Update(JobEntity job)
        {
            var objFromDb = _context.Job.Find(job);
            objFromDb.Company = job.Company;
            objFromDb.Location = job.Location;
            objFromDb.Salary = job.Salary;
            objFromDb.Title = job.Title;
            objFromDb.Time = job.Time;

            _context.SaveChanges();
        }

    }
}
