using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSearchApp.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        public string Description { get; set; }

        public int CompanySize { get; set; }

        public string Url { get; set; }

        public string PhoneNumber { get; set; }

        public byte[] Logo { get; set; }

        public virtual ICollection<JobEntity> JobEntity { get; set; }

    }
}
