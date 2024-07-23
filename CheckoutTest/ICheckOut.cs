using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTest
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
    public class Checkout
    {
        private readonly List<PriceList> _prices;
        public Checkout()
        {
            _prices = new List<PriceList>();
            _prices.Add(new PriceList("A", 50, 3, 130));
                /*
                 * A	50	3 for 130
B	30	2 for 45
C	20	
D	15*/
        }
    }
}
