using System;
using System.Collections.Generic;
using System.Text;
using JobSearchApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobSearchApp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }

        public DbSet<JobEntity> Job { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Technology> Technology { get; set; }

        public DbSet<JobApplication> JobApplication { get; set; }
    }
}
