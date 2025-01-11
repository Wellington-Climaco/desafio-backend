using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Base;

namespace PicPaySimplificado.Infraestructure.Extensions
{
    public static class MapBase
    {
        public static EntityTypeBuilder MappingBase<TEntity>(this EntityTypeBuilder<TEntity> builder) where  TEntity : EntityBase
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).IsRequired().ValueGeneratedNever();

            builder.Property(x=>x.CreatedAt).HasColumnType("timestamp(6)");
            return builder;
        }
    }
}
