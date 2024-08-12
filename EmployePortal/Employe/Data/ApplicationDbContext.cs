using System;
using Employe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace Employe.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Worker> Workers{ get; set; }
    }
}

