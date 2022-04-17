using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using OnlineTest.Contract.DataContracts;
using OnlineTest.Contract.DataModels;
using OnlineTest.Contract.Models;
using OnlineTest.Data.DbContext;

namespace OnlineTest.Data.Repository
{
    public class IncomeExpenseRepository : Repository<IncomeExpense>, IIncomeExpenseRepository
    {
        private readonly OnlineTestDbContext _dbContext;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public IncomeExpenseRepository(
            OnlineTestDbContext dbContext,
            ISqlConnectionFactory sqlConnectionFactory) : base(dbContext)
        {
            _dbContext = dbContext;
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<IEnumerable<IncomeExpenseDto>> GetAllIncomeExpenses(string year, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "Select " +
                      $"IE.Id AS {nameof(IncomeExpenseDto.Id)}, " +
                      $"IE.Year AS {nameof(IncomeExpenseDto.Year)}, " +
                      $"IE.Month AS {nameof(IncomeExpenseDto.Month)}, " +
                      "MS.Sequence, " +
                      $"IE.IncomeType1 AS {nameof(IncomeExpenseDto.IncomeType1)}, " +
                      $"IE.IncomeType2 AS {nameof(IncomeExpenseDto.IncomeType2)}, " +
                      $"IE.IncomeType3 AS {nameof(IncomeExpenseDto.IncomeType3)}, " +
                      $"IE.ExpenseType1 AS {nameof(IncomeExpenseDto.ExpenseType1)}, " +
                      $"IE.ExpenseType2 AS {nameof(IncomeExpenseDto.ExpenseType2)}, " +
                      $"IE.ExpenseType3 AS {nameof(IncomeExpenseDto.ExpenseType3)}, " +
                      $"IE.ExpenseType4 AS {nameof(IncomeExpenseDto.ExpenseType4)}, " +
                      "sum(COALESCE(IE.IncomeType1, 0) + COALESCE(IE.IncomeType2, 0) + COALESCE(IE.IncomeType3, 0) - " +
                      "COALESCE(IE.ExpenseType1, 0) - COALESCE(IE.ExpenseType2, 0) - COALESCE(IE.ExpenseType3, 0) - " +
                      "COALESCE(IE.ExpenseType4, 0)) " +
                      $"AS {nameof(IncomeExpenseDto.ReconciliationResult)}, " +
                      "sum(COALESCE(IE.IncomeType1, 0) + COALESCE(IE.IncomeType2, 0) + COALESCE(IE.IncomeType3, 0) - " +
                      "COALESCE(IE.ExpenseType1, 0) - COALESCE(IE.ExpenseType2, 0) - COALESCE(IE.ExpenseType3, 0) -" +
                      "COALESCE(IE.ExpenseType4, 0) + " +
                      "IC.Income - IC.Cost ) " +
                      $"AS {nameof(IncomeExpenseDto.FinalResult)} " +
                      "From IncomeExpenses AS IE " +
                      "INNER JOIN IncomeCosts IC " +
                      "ON IE.Month = IC.Month AND IE.Year =IC.Year " +
                      "Inner Join MonthSequences MS " +
                      "ON IE.Month = MS.Month " +
                      "WHERE IE.Year = @Year " +
                      "GROUP BY IE.Month,MS.Sequence,IE.Id,IE.Year,IE.IncomeType1,IE.IncomeType2," +
                      "IE.IncomeType3,IE.ExpenseType1,IE.ExpenseType2,IE.ExpenseType3," +
                      "IE.ExpenseType4 Order By MS.Sequence";

            return await connection
                .QueryAsync<IncomeExpenseDto>(sql, new { Year = year });
        }
    }
}
