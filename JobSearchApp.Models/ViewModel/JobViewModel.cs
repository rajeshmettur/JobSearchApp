using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearchApp.Models.ViewModel
{
    public class JobViewModel
    {
        public IEnumerable<SelectListItem> CompanyList { get; set; }

        public JobEntity JobEntity { get; set; }
    }
}
