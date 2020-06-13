using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearchApp.Models
{
    public class JobApplication
    {
        [Key]
        public Guid Id { get; set; }

        public Guid JobId { get; set; }

        [ForeignKey("JobId")]
        public JobEntity JobEntity { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser AppUser { get; set; }
    }
}
