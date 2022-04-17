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
    public class IncomeCostRepository : Repository<IncomeCost>, IIncomeCostRepository
    {
        private readonly OnlineTestDbContext _dbContext;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public IncomeCostRepository(
            OnlineTestDbContext dbContext,
            ISqlConnectionFactory sqlConnectionFactory) : base(dbContext)
        {
            _dbContext = dbContext;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<string>> GetYears(CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "Select DISTINCT IC.Year From IncomeCosts AS IC ";
            return await connection
                .QueryAsync<string>(sql);
        }
        public async Task<IEnumerable<IncomeCostDto>> GetAllIncomeCosts(string year, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var sql = "Select " +
                      $"IC.Id AS {nameof(IncomeCostDto.Id)}, " +
                      $"IC.Year AS {nameof(IncomeCostDto.Year)}, " +
                      $"IC.Month AS {nameof(IncomeCostDto.Month)}, " +
                      $"IC.Income AS {nameof(IncomeCostDto.Income)}, " +
                      $"IC.CumulativeIncome AS {nameof(IncomeCostDto.CumulativeIncome)}, " +
                      $"IC.Cost AS {nameof(IncomeCostDto.Cost)}, " +
                      $"IC.CumulativeCost AS {nameof(IncomeCostDto.CumulativeCost)}," +
                      $"IC.Income-Ic.Cost AS {nameof(IncomeCostDto.Result)} " +
                      "From IncomeCosts AS IC " +
                      "Inner Join MonthSequences MS " +
                      "ON IC.Month = MS.Month " +
                      "WHERE IC.Year = @Year Order By Sequence";
            return await connection
                .QueryAsync<IncomeCostDto>(sql, new { Year = year });
        }
    }
}
