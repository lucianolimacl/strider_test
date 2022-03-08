using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Domain.Models;

namespace Strider.Infra.EntityConfig
{
    public class UserProfileEntityConfig : BaseEntityConfig<UserModel>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.DateJoined)
                .IsRequired();

            builder.HasMany(x => x.Posts).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }

        protected override string GetTableName()
        {
            return "UserProfile";
        }
    }
}
