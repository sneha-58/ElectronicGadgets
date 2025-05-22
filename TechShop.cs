using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public class TechShop
    {
        private List<Products> productList = new List<Products>();
        private List<Orders> ordersList = new List<Orders>();
        private SortedList<int, Inventory> inventoryList = new SortedList<int, Inventory>();

        // Managing Products List
        public void AddProduct(Products product)
        {
            if (productList.Any(p => p.ProductID == product.ProductID))
                throw new InvalidDataException("Product with the same ID already exists.");

            productList.Add(product);
            inventoryList.Add(product.ProductID, new Inventory(product.ProductID, product, product.Stock));
        }

        public void UpdateProduct(int productId, string? description = null, decimal? price = null)
        {
            var product = productList.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                throw new InvalidDataException("Product not found.");

            product.UpdateProductInfo(description, price);
        }

        public void RemoveProduct(int productId)
        {
            var product = productList.FirstOrDefault(p => p.ProductID == productId);
            if (product == null)
                throw new InvalidDataException("Product not found.");

            if (ordersList.Any(o => o.HasProduct(product)))
                throw new InvalidDataException("Cannot remove product associated with existing orders.");

            productList.Remove(product);
            inventoryList.Remove(productId);
        }

        // Managing Orders List
        public void AddOrder(Orders order)
        {
            ordersList.Add(order);
        }

        public void UpdateOrderStatus(int orderId, string status)
        {
            var order = ordersList.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
                throw new InvalidDataException("Order not found.");

            order.UpdateStatus(status);
        }

        public void RemoveCanceledOrder(int orderId)
        {
            var order = ordersList.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null || order.GetStatus() != "Cancelled")
                throw new InvalidDataException("Only cancelled orders can be removed.");

            ordersList.Remove(order);
        }


        // Sorting Orders by Date
        public List<Orders> GetOrdersSortedByDate(bool ascending = true)
        {
            return ascending ? ordersList.OrderBy(o => o.OrderDate).ToList() : ordersList.OrderByDescending(o => o.OrderDate).ToList();
        }

        // Product Search
        public List<Products> SearchProducts(string keyword)
        {
            return productList.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
