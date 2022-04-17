using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.Contracts;
using OnlineTest.Contract.DataContracts;
using OnlineTest.Data.DbContext;

namespace OnlineTest.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineTestDbContext _context;

        public UnitOfWork(OnlineTestDbContext context,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            _context = context;
            DbContext = context;
            IncomeCostRepository = new IncomeCostRepository(_context, sqlConnectionFactory);
            IncomeExpenseRepository = new IncomeExpenseRepository(_context, sqlConnectionFactory);

        }
        public Microsoft.EntityFrameworkCore.DbContext DbContext { get; }
        public  IIncomeCostRepository IncomeCostRepository { get; }
        public IIncomeExpenseRepository IncomeExpenseRepository { get; }


        public async Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
