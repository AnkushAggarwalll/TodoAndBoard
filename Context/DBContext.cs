using Microsoft.EntityFrameworkCore;
using todoonboard_api.Models;

namespace todoonboard_api.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<Boards> Boards { get; set; } = null!;
        public DbSet<Todo> Todos { get; set; } = null!;
        
    }
}