using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public class Products
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Products(int id, string name, string description, decimal price, int stock)
        {
            this.ProductID = id;
            this.ProductName = name;
            this.Description = description;
            this.Price = price >= 0 ? price : 0;
            this.Stock = stock;
        }

        public string GetProductDetails()
        {
            return $"ProductID: {ProductID}, Name: {ProductName}, Description: {Description}, Price: {Price:C}, Stock: {Stock}";
        }
        public decimal GetPrice()
        {
            return Price;
        }

        public void UpdateProductInfo(string? description = null, decimal? price = null)
        {
            if (description != null)
            {
                this.Description = description;
            }
            if (price != null && price >= 0)
            {
                this.Price = (decimal)price;
            }
        }
    }
    
}
