using System;

namespace OnlineTest.Contract.Models
{
    public sealed class IncomeCost
    {
        public Guid Id { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public int Income { get; set; }
        public int CumulativeIncome { get; set; }
        public int Cost { get; set; }
        public int CumulativeCost { get; set; }
    }
}
