using Microsoft.EntityFrameworkCore;
using Strider.Domain.Models;
using Strider.Infra.EntityConfig;

namespace Strider.Infra
{
    public class StriderDbContext : DbContext
    {
        public StriderDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserProfileEntityConfig());
            modelBuilder.ApplyConfiguration(new UserFollowerEntityConfig());
            modelBuilder.ApplyConfiguration(new PostEntityConfig());
        }

        public DbSet<PostModel>? Posts { get; set; }
        public DbSet<UserModel>? Users { get; set; }
        public DbSet<UserFollowModel>? UserFollows { get; set; }
    }
}
