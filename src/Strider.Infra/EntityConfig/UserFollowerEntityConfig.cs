using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Domain.Models;

namespace Strider.Infra.EntityConfig
{
    public class UserFollowerEntityConfig : BaseEntityConfig<UserFollowModel>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserFollowModel> builder)
        {
            builder.HasOne(x => x.UserFollowed).WithMany(x => x.Followers).HasForeignKey(x => x.UserFollowedId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FollowingUser).WithMany(x => x.Following).HasForeignKey(x => x.FollowingUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => new { x.UserFollowedId, x.FollowingUserId }).IsUnique();
        }

        protected override string GetTableName()
        {
            return "UserFollow";
        }
    }
}
