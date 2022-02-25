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
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<BoardsUser> BoardsUser {get; set;}= null!;
        
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<BoardsUser>().HasKey(sc => new { sc.BoardsId , sc.UserId});
        }
    }
}