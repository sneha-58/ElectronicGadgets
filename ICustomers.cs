using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicGadgetsLibrary
{
    public interface ICustomers
    {
        Customers GetCustomerByID(int id);
        Customers GetCustomerByName(string name);
        void AddCustomer(Customers product);
        void UpdateCustomer(Customers product);
        void DeleteCustomer(int id);
        List<Customers> GetAllCustomers();
    }
}
