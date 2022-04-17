using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using OnlineTest.Contract.BusinessContracts;
using OnlineTest.Contract.DataModels;

namespace OnlineTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReconciliationController : ControllerBase
    {
        private readonly IReconciliationHandler _reconciliationHandler;

        public ReconciliationController(IReconciliationHandler reconciliationHandler)
        {
            this._reconciliationHandler = reconciliationHandler;
        }

        [HttpGet(nameof(GetYears))]
        public async Task<IEnumerable<string>> GetYears(CancellationToken cancellationToken)
        {
            return await _reconciliationHandler.GetYears(cancellationToken);
        }

        [HttpGet(nameof(GetAllIncomeCosts))]
        public async Task<IEnumerable<IncomeCostDto>> GetAllIncomeCosts(string year, CancellationToken cancellationToken)
        {
            return await _reconciliationHandler.GetAllIncomeCosts(year, cancellationToken);
        }

        [HttpGet(nameof(GetAllIncomeExpenses))]
        public async Task<IEnumerable<IncomeExpenseDto>> GetAllIncomeExpenses(string year, CancellationToken cancellationToken)
        {
            var incomeExpense = await _reconciliationHandler.GetAllIncomeExpenses(year, cancellationToken);
            var prev = 0;
            foreach (var ie in incomeExpense)
            {
                ie.CumulativeFinalResult = ie.FinalResult + prev;
                prev = ie.CumulativeFinalResult;
            }

            return incomeExpense;
        }

        [HttpPatch(nameof(UpdateIncomeExpense))]
        public async Task<IActionResult> UpdateIncomeExpense(UpdateIncomeExpenseCommand updateIncomeExpenseCommand,
            CancellationToken cancellationToken)
        {
            await _reconciliationHandler
                .UpdateIncomeExpense(updateIncomeExpenseCommand, cancellationToken);
            return Ok(HttpStatusCode.OK);
        }
    }
}
