using JobSearchApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.DataAccess.Repository.IRepository
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        IEnumerable<SelectListItem> GetSkillsLists();
        void Update(Technology job);
    }
}
