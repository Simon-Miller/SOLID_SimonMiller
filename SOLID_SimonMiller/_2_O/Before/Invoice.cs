namespace SOLID_SimonMiller._2_O.Before
{
    public enum DiscountCodes
    {
        NONE = 0,
        Promo10,
        Staff25
    }

    /*
        Although this looks easy to contain, the cases themselves may get a lot more complicated.
        If we add more cases, because of other factors, (double discount, black friday, etc) then we'd have to modify this code,
        therefore needing to test all cases, and not just the additional case.
     */

    public class Invoice
    {
        public decimal CalcAmountWithDiscount(decimal amount, DiscountCodes code = DiscountCodes.NONE)
        {
            switch (code)
            {
                case DiscountCodes.Promo10:
                    return amount * 0.9M;

                case DiscountCodes.Staff25:
                    return amount * 0.75M;

                case DiscountCodes.NONE:
                default:
                    return amount;
            }
        }
    }
}
