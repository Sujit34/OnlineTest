using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.Contracts;
using OnlineTest.Contract.DataModels;
using OnlineTest.Contract.Models;

namespace OnlineTest.Contract.DataContracts
{
    public interface IIncomeExpenseRepository:IRepository<IncomeExpense>
    {
        Task<IEnumerable<IncomeExpenseDto>> GetAllIncomeExpenses(string year, CancellationToken cancellationToken);
    }
}
