using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public class Orders
    {
        public int OrderID { get; set; }
        public Customers Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        private List<OrderDetails> orderDetails = new List<OrderDetails>();

        public Orders(int id, Customers customer)
        {
            this.OrderID = id;
            this.Customer = customer;
            this.OrderDate = DateTime.Now;
        }

        public decimal CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (var detail in orderDetails)
            {
                TotalAmount += detail.CalculateSubtotal();
            }
            return TotalAmount;
        }

        private string status = "Pending"; // Default status

        public void UpdateStatus(string newStatus)
        {
            if (string.IsNullOrEmpty(newStatus))
                throw new InvalidDataException("Order status cannot be empty.");

            status = newStatus;
        }

        public string GetStatus() => status;

        public bool HasProduct(Products product)
        {
            return orderDetails.Any(od => od.GetProduct().ProductID == product.ProductID);
        }
    }
}
