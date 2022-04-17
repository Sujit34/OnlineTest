using System;

namespace OnlineTest.Contract.DataModels
{
    public class IncomeExpenseDto
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int? IncomeType1 { get; set; }
        public int? IncomeType2 { get; set; }
        public int? IncomeType3 { get; set; }
        public int? ExpenseType1 { get; set; }
        public int? ExpenseType2 { get; set; }
        public int? ExpenseType3 { get; set; }
        public int? ExpenseType4 { get; set; }
        public int ReconciliationResult { get; set; }
        public int FinalResult { get; set; }
        public int CumulativeFinalResult { get; set; }

    }
}
