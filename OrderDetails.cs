using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }
        public Orders Order { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }

        public OrderDetails(int id, Orders order, Products product, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidDataException("Quantity must be greater than zero.");
            }

            if (product == null)
            {
                throw new IncompleteOrderException("Order detail must have a valid product.");
            }

            this.OrderDetailID = id;
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity > 0 ? quantity : 1;
        }
        public Products GetProduct() => Product;

        public decimal CalculateSubtotal() => Quantity * Product.GetPrice();
    }
}
