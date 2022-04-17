using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineTest.Contract.Models;

namespace OnlineTest.Data.EntityConfigurations
{
    public class IncomeExpenseEntityTypeConfiguration : IEntityTypeConfiguration<IncomeExpense>
    {
        public void Configure(EntityTypeBuilder<IncomeExpense> builder)
        {
            builder.ToTable("IncomeExpenses");
            builder.Property(u => u.Id).HasDefaultValueSql();
            builder.HasKey(u => u.Id);
        }
    }
}
