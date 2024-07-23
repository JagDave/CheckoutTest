using CheckoutTest;

namespace CheckoutUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1(List<string> items, int expected)
        {
            //Setup pricelist to use
            List<PriceListItem> prices = new List<PriceListItem>();
            prices.Add(new PriceListItem("A", 50, 3, 130));
            prices.Add(new PriceListItem("B", 30, 2, 45));
            prices.Add(new PriceListItem("C", 20, 0, 0));
            prices.Add(new PriceListItem("D", 15, 0, 0));

            List<IDiscount> discounts = new List<IDiscount>();
            discounts.Add(new Discount("A", 3, 130));
            discounts.Add(new Discount("B", 2, 45));

            ICheckout checkout = new Checkout(prices, discounts);


            //Scan items
            foreach (var item in items)
            {
                checkout.Scan(item);
            }

            //Calculate Discounts

            //Calculate total price
            Assert.Equal(expected, checkout.GetTotalPrice());
        }
    }
}