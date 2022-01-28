using E_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Project.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
                
        }

        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
