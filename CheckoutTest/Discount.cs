namespace CheckoutTest
{
    public class Discount : IDiscount
    {
        public string DiscountItem { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
        public Discount(string discountItem, int discountQty, int discountAmount)
        {
            DiscountItem = discountItem;
            DiscountQty = discountQty;
            DiscountAmount = discountAmount;
        }
    }
}
