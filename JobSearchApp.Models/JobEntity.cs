using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearchApp.Models
{
    public class JobEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name ="Job Title")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
      
        [Required]
        public Guid CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public string Salary { get; set; }
        //public enum JobTitle { NA = 0, Permanent = 1, Contract = 2 }

        [Display(Name = "Work Location")]
        public string Location { get; set; }

        [Display(Name = "Working Hours")]
        public string Time { get; set; }

    }

}
