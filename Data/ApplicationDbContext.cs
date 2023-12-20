using HospitalManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<doctors> Doctors { get; set; }

        public DbSet<department> Departments { get; set; }

        public DbSet<users> Users { get; set; }

    }
}
