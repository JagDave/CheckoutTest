namespace CheckoutTest
{
    public class Checkout : ICheckout
    {
        private readonly List<IPriceListItem> _prices;
        private readonly List<IDiscount> _discounts;
        private List<string> _basket = new List<string>();
        public Checkout(List<IPriceListItem> pricelist, List<IDiscount> discounts)
        {
            _prices = pricelist;
            _discounts = discounts;
        }

        public int GetTotalPrice()
        {
            if (_basket == null || !_basket.Any() || _prices ==null || !_prices.Any())
            {
                return 0;
            }

            var distinctItems = _basket.Distinct();
            int total = 0;
                        
            foreach (var prod in distinctItems)
            {
                int itemCount = _basket.Count(p => p == prod);
                var discount = _discounts.FirstOrDefault(d => d.DiscountItem == prod && d.DiscountQty > 0 && d.DiscountAmount > 0);
                int itemPrice = _prices.First(p => p.ItemName == prod).ItemPrice;

                if (discount != null)
                {
                    int discountQty = discount.DiscountQty;
                    int discountAmount = discount.DiscountAmount;
                    int discountedItems = (itemCount / discountQty) * discountAmount;
                    int nonDiscountedItems = (itemCount % discountQty) * itemPrice;
                    total += discountedItems + nonDiscountedItems;
                }
                else
                {
                    total += itemCount * itemPrice;
                }
            }
            return total;
        }

        public void Scan(string item)
        {
            _basket.Add(item);
        }
    }
}
