using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Domain.Models;

namespace Strider.Infra.EntityConfig
{
    public class PostEntityConfig : BaseEntityConfig<PostModel>
    {
        public override void ConfigureEntity(EntityTypeBuilder<PostModel> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(777);

            builder.Property(x => x.PostType)
                .IsRequired();

            builder.Property(x => x.DateCreated)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.QuotePost)
               .WithMany()
               .HasForeignKey(x => x.QuotePostId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            builder.HasOne(x => x.Repost)
               .WithMany()
               .HasForeignKey(x => x.RepostPostId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);
        }

        protected override string GetTableName()
        {
            return "Post";
        }
    }
}
