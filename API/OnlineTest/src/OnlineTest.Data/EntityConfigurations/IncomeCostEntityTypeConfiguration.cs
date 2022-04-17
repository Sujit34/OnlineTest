using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineTest.Contract.Models;

namespace OnlineTest.Data.EntityConfigurations
{
    public class IncomeCostEntityTypeConfiguration : IEntityTypeConfiguration<IncomeCost>
    {
        public void Configure(EntityTypeBuilder<IncomeCost> builder)
        {
            builder.ToTable("IncomeCosts");
            builder.Property(u => u.Id).HasDefaultValueSql();
            builder.HasKey(u => u.Id);
        }
    }
}
