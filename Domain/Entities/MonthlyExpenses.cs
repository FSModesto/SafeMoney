using Domain.Enums;

namespace Domain.Entities
{
    public class MonthlyExpenses
    {
        public int Id { get; set; }
        public string Month {  get; set; }
        public decimal Limit { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }
        public decimal Total { get; set; }
    }
}
