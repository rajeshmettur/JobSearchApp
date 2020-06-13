using JobSearchApp.DataAccess.Data;
using JobSearchApp.DataAccess.Repository.IRepository;
using JobSearchApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JobSearchApp.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        protected readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetCompanyLists()
        {
            return _context.Company.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            }); 
        }
        public void Update(Company company)
        {
            var objFromDb = _context.Company.FirstOrDefault(x => x.Id == company.Id);

            objFromDb.Name = company.Name;
            objFromDb.Description = company.Description;
            objFromDb.PhoneNumber = company.PhoneNumber;
            objFromDb.Url = company.Url;
            objFromDb.CompanySize = company.CompanySize;
            objFromDb.Logo = company.Logo;

            _context.SaveChanges();
        }
    }
}
