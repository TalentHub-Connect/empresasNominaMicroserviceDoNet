using empresasNominaMicroserviceDoNet.Models;
using Microsoft.EntityFrameworkCore;

namespace empresasNominaMicroserviceDoNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Candidate> candidate { get; set; }
        public DbSet<Employee> employee { get; set; }

    }
}
