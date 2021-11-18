namespace SOLID_SimonMiller._2_O.After
{
    public record class Staff25InvoiceValue : StandardInvoiceValue
    {
        public Staff25InvoiceValue(decimal Amount) : base(Amount * 0.75M)
        {
        }
    }
}
