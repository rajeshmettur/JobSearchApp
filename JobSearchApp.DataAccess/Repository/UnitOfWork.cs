using JobSearchApp.DataAccess.Data;
using JobSearchApp.DataAccess.Repository.IRepository;
using JobSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public ICompanyRepository Company { get; private set; }

        public IJobRepository Job { get; private set; }

        public ITechnologyRepository Technology { get; private set; }

        public IJobApplicationRepository JobApplication { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Company = new CompanyRepository(_context);
            Job = new JobRepository(_context);
            Technology = new TechnologyRepository(_context);
            JobApplication = new JobApplicationRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
