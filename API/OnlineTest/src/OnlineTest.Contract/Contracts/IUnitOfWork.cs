using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineTest.Contract.DataContracts;

namespace OnlineTest.Contract.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IIncomeCostRepository IncomeCostRepository { get; }
        IIncomeExpenseRepository IncomeExpenseRepository { get; }
        DbContext DbContext { get; }
        Task<int> CommitAsync(CancellationToken cancellationToken);
    }
}
