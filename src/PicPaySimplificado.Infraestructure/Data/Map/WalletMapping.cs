using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Entities;
using PicPaySimplificado.Infraestructure.Extensions;

namespace PicPaySimplificado.Infraestructure.Data.Map
{
    public class WalletMapping : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.MappingBase();         
        }
    }
}
