namespace EbanxAssignment.Models
{
    public class BankTransaction
    {
        public string Type { get; set; }
        public string? Destination { get; set; }
        public int Amount { get; set; }
        public string? Origin { get; set; }
    }
}
