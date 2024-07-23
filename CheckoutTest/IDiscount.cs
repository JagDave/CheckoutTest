namespace CheckoutTest
{
    public interface IDiscount
    {
        public string DiscountItem { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
    }
}
