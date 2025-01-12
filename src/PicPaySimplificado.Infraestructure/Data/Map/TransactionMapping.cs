using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Infraestructure.Extensions;

namespace PicPaySimplificado.Infraestructure.Data.Map
{
    internal class TransactionMapping : IEntityTypeConfiguration<Transference>
    {
        public void Configure(EntityTypeBuilder<Transference> builder)
        {
            builder.MappingBase();

            builder.Property(x => x.Status).HasColumnType("text");
        }
    }
}
