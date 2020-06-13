using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable 
    {
        ICompanyRepository Company { get; }

        IJobRepository Job { get; }

        ITechnologyRepository Technology { get;  }

        IJobApplicationRepository JobApplication { get; }

        void Save();
    }
}
