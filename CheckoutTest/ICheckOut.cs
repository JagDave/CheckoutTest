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
    public class Checkout : ICheckout
    {
        private readonly List<PriceListItem> _prices;
        private readonly List<Discount> _discounts;
        private List<string> _basket = new List<string>();
        public Checkout(List<PriceListItem> pricelist, List<Discount> discounts )
        {
            _prices = pricelist;
            _discounts = discounts;
        }

        public int GetTotalPrice()
        {
            //Get a distinct list of items
            List<string> _distinctItems = _basket.Distinct();
            int total = 0;

            foreach (var prod in _distinctItems)
            {
                //get count from basket
                int itemCount = _basket.Count(p => p == prod);

                //Calc discount items
                if (_discounts.Any(d => d.DiscountItem == prod))
                {
                    int discountNo = _discounts.First(d => d.DiscountItem == prod).DiscountQty;
                    if (discountNo != 0) {
                        int xDiscount = (itemCount / discountNo);
                    }


                }

                //calc remainder
            }
        }

        public void Scan(string item)
        {
            basket.Add(item);
        }
    }
    public interface IPriceListItem
    {
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
    }
    public class PriceListItem : IPriceListItem
    {

        public string ItemName { get; set; }
        public int ItemPrice { get; set; }

        public PriceListItem(string itemName, int itemPrice, int discountQty = 0, int discountAmount = 0)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
        }
    }
    public interface IDiscount
    {
        public string DiscountItem { get; set; }
        public int DiscountQty { get; set; }
        public int DiscountAmount { get; set; }
    }

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
