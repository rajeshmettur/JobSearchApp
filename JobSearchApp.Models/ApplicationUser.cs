using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobSearchApp.Models
{
   public class ApplicationUser :  IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string TotalExp { get; set; }
        public string Skills { get; set; }
        public string Industry { get; set; }

    }
}

