using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.Models.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<Company> CompanyList { get; set; }
        public IEnumerable<JobEntity> JobList { get; set; }
        public IEnumerable<Technology> TechnologyList { get; set; }
        public IEnumerable<JobApplication> ApplicationList { get; set; }
        public JobEntity JobEntity { get; set; }

    }
}
