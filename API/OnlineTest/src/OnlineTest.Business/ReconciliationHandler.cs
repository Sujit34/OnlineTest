using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.BusinessContracts;
using OnlineTest.Contract.Contracts;
using OnlineTest.Contract.DataModels;

namespace OnlineTest.Business
{
    public class ReconciliationHandler : IReconciliationHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReconciliationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<string>>GetYears( CancellationToken cancellationToken)
        {
            return _unitOfWork.IncomeCostRepository.GetYears(cancellationToken);
        }
        public Task<IEnumerable<IncomeCostDto>> GetAllIncomeCosts(string year, CancellationToken cancellationToken)
        {
             return  _unitOfWork.IncomeCostRepository.GetAllIncomeCosts(year, cancellationToken);
        }

        public Task<IEnumerable<IncomeExpenseDto>> GetAllIncomeExpenses(string year, CancellationToken cancellationToken)
        {
            return _unitOfWork.IncomeExpenseRepository.GetAllIncomeExpenses(year, cancellationToken);
        }

        public async Task UpdateIncomeExpense(UpdateIncomeExpenseCommand updateIncomeExpenseCommand,
            CancellationToken cancellationToken)
        {
            var incomeExpense = await _unitOfWork.IncomeExpenseRepository
                .GetAsync(Guid.Parse(updateIncomeExpenseCommand.Id), cancellationToken);
            
            incomeExpense.IncomeType1 = updateIncomeExpenseCommand.IncomeType1;
            incomeExpense.IncomeType2 = updateIncomeExpenseCommand.IncomeType2;
            incomeExpense.IncomeType3 = updateIncomeExpenseCommand.IncomeType3;
            incomeExpense.ExpenseType1 = updateIncomeExpenseCommand.ExpenseType1;
            incomeExpense.ExpenseType2 = updateIncomeExpenseCommand.ExpenseType2;
            incomeExpense.ExpenseType3 = updateIncomeExpenseCommand.ExpenseType3;
            incomeExpense.ExpenseType4 = updateIncomeExpenseCommand.ExpenseType4;

            await _unitOfWork.CommitAsync(cancellationToken);
        }

    }
}
