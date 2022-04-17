using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.DataModels;

namespace OnlineTest.Contract.BusinessContracts
{
    public interface IReconciliationHandler
    {
        Task<IEnumerable<string>> GetYears(CancellationToken cancellationToken);
        Task<IEnumerable<IncomeCostDto>> GetAllIncomeCosts(string year, CancellationToken cancellationToken);

        Task<IEnumerable<IncomeExpenseDto>> GetAllIncomeExpenses(string year, CancellationToken cancellationToken);

        Task UpdateIncomeExpense(UpdateIncomeExpenseCommand updateIncomeExpenseCommand,
            CancellationToken cancellationToken);
    }
}
