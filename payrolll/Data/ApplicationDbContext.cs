using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using payrolll.Models;

namespace payrolll.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<payrolll.Models.Employeemasterdata> Employeemasterdata { get; set; } = default!;
        public DbSet<payrolll.Models.attendance> attendance { get; set; } = default!;
        public DbSet<payrolll.Models.Allowance> Allowance { get; set; } = default!;

    }
}