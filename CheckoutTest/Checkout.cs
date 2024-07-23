namespace CheckoutTest
{
    public class Checkout : ICheckout
    {
        private readonly List<PriceListItem> _prices;
        private readonly List<Discount> _discounts;
        private List<string> _basket = new List<string>();
        public Checkout(List<PriceListItem> pricelist, List<Discount> discounts)
        {
            _prices = pricelist;
            _discounts = discounts;
        }

        public int GetTotalPrice()
        {
            //Get a distinct list of items
            List<string> _distinctItems = _basket.Distinct().ToList();
            int total = 0;

            foreach (var prod in _distinctItems)
            {
                //get count from basket
                int itemCount = _basket.Count(p => p == prod);
                int xDiscount = 0;
                int discountNo = 0;
                int NotDiscounted = 0;
                //Calc discount items
                if (_discounts.Any(d => d.DiscountItem == prod && d.DiscountQty > 0 && d.DiscountAmount > 0))
                {
                    discountNo = _discounts.First(d => d.DiscountItem == prod && d.DiscountQty > 0 && d.DiscountAmount > 0).DiscountQty;
                    if (discountNo != 0)
                    {
                        xDiscount = (itemCount / discountNo) * _discounts.First(d => d.DiscountItem == prod && d.DiscountQty > 0 && d.DiscountAmount > 0).DiscountAmount;

                    }

                    //calc remainder
                    NotDiscounted = (itemCount % discountNo) * _prices.First(p => p.ItemName == prod).ItemPrice;
                }
                else
                {
                    NotDiscounted = itemCount * _prices.First(p => p.ItemName == prod).ItemPrice;
                }

                total = total + xDiscount + NotDiscounted;


            }
            return total;
        }

        public void Scan(string item)
        {
            _basket.Add(item);
        }
    }
}
