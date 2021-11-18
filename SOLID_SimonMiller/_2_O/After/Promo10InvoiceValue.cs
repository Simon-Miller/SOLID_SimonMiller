namespace SOLID_SimonMiller._2_O.After
{
    public record class Promo10InvoiceValue : StandardInvoiceValue
    {
        public Promo10InvoiceValue(decimal Amount) : base(Amount * 0.9M)
        {
        }
    }
}
