using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.Contracts;
using OnlineTest.Contract.DataModels;
using OnlineTest.Contract.Models;

namespace OnlineTest.Contract.DataContracts
{
    public interface IIncomeCostRepository : IRepository<IncomeCost>
    {
        Task<IEnumerable<string>> GetYears(CancellationToken cancellationToken);
        Task<IEnumerable<IncomeCostDto>> GetAllIncomeCosts(string year, CancellationToken cancellationToken);
    }
}
