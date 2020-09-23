using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AccountDetails> AccountDetails { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserCollections> UserCollections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=HoarderDB.db;");
        }
    }



}