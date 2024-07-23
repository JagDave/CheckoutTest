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
    public class Checkout:ICheckout
    {
        private readonly List<PriceListItem> _prices;
        private List<string> basket = new List<string> ();
        public Checkout(List<PriceListItem> pricelist)
        {
            _prices = pricelist;
        }

        public int GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new NotImplementedException();
        }
    }
    public interface IPriceListItem
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
    }
    public class PriceListItem : IPriceListItem
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
