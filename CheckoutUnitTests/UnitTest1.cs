using CheckoutTest;

namespace CheckoutUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1(List<string> items,int expected)
        {
            //Scan items
            ICheckout checkout = new Checkout();

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