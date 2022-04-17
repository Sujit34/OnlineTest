using System;

namespace OnlineTest.Contract.Models
{
    public sealed class IncomeExpense
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
    }
}
