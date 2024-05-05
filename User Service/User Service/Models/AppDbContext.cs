using Microsoft.EntityFrameworkCore;
using User_Service.Models;

namespace User_Service.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<SpeechTherapist> SpeechTherapists { get; set; }
    }
}
