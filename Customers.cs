using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ElectronicGadgetsLibrary
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        private List<Orders> orders = new List<Orders>();
        public Customers(int customerID,string firstName, string lastName,string email,string phone,string address)
        {
            if (!email.Contains("@"))
            {
                throw new InvalidDataException("Invalid email address.");
            }

            this.CustomerID = customerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
        public Customers() { }

        // GET TOTAL ORDERS COUNT
        public int CalculateTotalOrders() => orders.Count;
        // DISPLAY DETAILS
        public string GetCustomerDetails()
        {
            string title = string.Format("{0,4}{1,20}{2,15},{3,12}{4,20}", "Customer ID", "Customer Name", "Email", "Phone", "Address");
            string details = string.Format("{0,4}{1,20}{2,15},{3,12}{4,20}", CustomerID, FirstName + " " + LastName, Email, Phone, Address);
            return title + "\n" + details;
        }
        // UPDATE 
        public void UpdateCustomerInfo(string? email = null, string? phone = null, string? address = null)
        {
            if (email != null && !email.Contains("@"))
            {
                throw new InvalidDataException("Invalid email address.");
            }
            if (email != null)
            {
                this.Email = email;
            }
            if (phone != null)
            {
                this.Phone = phone;
            }
            if (address != null)
            {
                this.Address = address;
            }
        }

        
    }
}
