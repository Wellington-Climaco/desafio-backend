using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Infraestructure.Extensions;

namespace PicPaySimplificado.Infraestructure.Data.Map
{
    internal class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.MappingBase();
        }
    }
}
