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
    public class TechnologyRepository : Repository<Technology>, ITechnologyRepository
    {
        protected readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSkillsLists()
        {
            return _context.Technology.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(Technology skill)
        {
            var objFromDb = _context.Technology.FirstOrDefault(x => x.Id == skill.Id);

            objFromDb.Name = skill.Name;
            objFromDb.Picture = skill.Picture;
            objFromDb.IsActive = skill.IsActive;

            _context.SaveChanges();
        }
    }
}
