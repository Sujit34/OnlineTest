using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Contract.Models;

namespace OnlineTest.Data.DbContext
{
    public sealed class OnlineTestDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<IncomeCost> IncomeCosts { get; set; }
        public DbSet<IncomeExpense> IncomeExpenses { get; set; }
        public OnlineTestDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
