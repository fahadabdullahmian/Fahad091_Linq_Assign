using BlazorLinq.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorLinq.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student>? studen { get; set; }
        public DbSet<Class>? Cla { get; set; }
        public DbSet<Faculty>? Faculti { get; set; }
        public DbSet<Enrolled>? Enrolled { get; set; }
    }
}
