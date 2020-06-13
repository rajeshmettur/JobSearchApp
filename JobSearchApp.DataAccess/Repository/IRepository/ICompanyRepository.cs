using JobSearchApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<SelectListItem> GetCompanyLists();
        void Update(Company company);
    }
}
