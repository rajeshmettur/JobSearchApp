using JobSearchApp.DataAccess.Data;
using JobSearchApp.DataAccess.Repository.IRepository;
using JobSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JobSearchApp.DataAccess.Repository
{
    public class JobApplicationRepository : Repository<JobApplication>, IJobApplicationRepository
    {

        protected readonly ApplicationDbContext _context;

        public JobApplicationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(JobApplication jobapp)
        {
            var objFromDb = _context.JobApplication.FirstOrDefault(x => x.Id == jobapp.Id);

            objFromDb.JobId = jobapp.JobId;
            objFromDb.UserId = jobapp.UserId;
            
            _context.SaveChanges();
        }
    }
}
