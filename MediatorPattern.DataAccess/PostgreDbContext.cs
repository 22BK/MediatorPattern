using MediatorPattern.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.DataAccess
{
    public class PostgreDbContext:DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        
    }
}
