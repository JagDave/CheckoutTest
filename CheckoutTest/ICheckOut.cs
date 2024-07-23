using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        private readonly List<PriceListItem> _prices;
        public Checkout()
        {
            _prices = new List<PriceList>();
            _prices.Add(new PriceList("A", 50, 3, 130));
            _prices.Add(new PriceList("B", 30, 2, 45));
            _prices.Add(new PriceList("C", 20, 0, 0));
            _prices.Add(new PriceList("D", 15, 0, 0));


        }
    }
    interface IPriceListItem
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
    }
    class PriceListItem : IPriceListItem
    {

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
        
        public PriceListItem(string itemName, int itemPrice, int discountQty = 0, int discountAmount = 0)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            DiscountQty= discountQty;
            DiscountAmount = discountAmount;
        }
    }
}
