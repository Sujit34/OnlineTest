using System;

namespace OnlineTest.Contract.DataModels
{
    public class IncomeCostDto
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int Income { get; set; }
        public int CumulativeIncome { get; set; }
        public int Cost { get; set; }
        public int CumulativeCost { get; set; }
        public int Result { get; set; }
    }
}
