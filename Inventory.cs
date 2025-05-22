using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public class Inventory
    {
        public  int InventoryID { get; set; }
        public Products Product { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

        public Inventory(int id, Products product, int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidDataException("Stock quantity cannot be negative.");
            }

            this.InventoryID = id;
            this.Product = product;
            this.QuantityInStock = quantity;
            this.LastStockUpdate = DateTime.Now;
        }
        public void UpdateStock(int quantity)
        {
            if (QuantityInStock + quantity < 0)
            {
                throw new InsufficientStockException("Not enough stock available.");
            }

            QuantityInStock += quantity;
            LastStockUpdate = DateTime.Now;
        }
    }
}
