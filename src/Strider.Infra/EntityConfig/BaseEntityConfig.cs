using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Strider.Domain.Models;

namespace Strider.Infra.EntityConfig
{
    public abstract class BaseEntityConfig<TModel> : IEntityTypeConfiguration<TModel> where TModel : BaseModel
    {
        public void Configure(EntityTypeBuilder<TModel> builder)
        {
            builder.ToTable(GetTableName());
            builder.HasKey(x => x.Id);

            ConfigureEntity(builder);
        }

        protected abstract string GetTableName();

        public abstract void ConfigureEntity(EntityTypeBuilder<TModel> builder);
    }
}
