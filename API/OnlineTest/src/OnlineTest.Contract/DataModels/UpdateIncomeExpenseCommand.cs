namespace OnlineTest.Contract.DataModels
{
    public class UpdateIncomeExpenseCommand
    {
        public string Id { get; set; }
        public int? IncomeType1 { get; set; }
        public int? IncomeType2 { get; set; }
        public int? IncomeType3 { get; set; }
        public int? ExpenseType1 { get; set; }
        public int? ExpenseType2 { get; set; }
        public int? ExpenseType3 { get; set; }
        public int? ExpenseType4 { get; set; }
       
    }
}
