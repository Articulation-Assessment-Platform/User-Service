using Microsoft.EntityFrameworkCore;
using User_Service.Models;

namespace User_Service.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }


        public DbSet<SpeechTherapist> SpeechTherapist { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Parent> Parent { get; set; }
    }
}
