using ElectronicGadgetsLibrary;

public class CustomerHelper
{
    private readonly CustomerService service = new CustomerService();

    public void InsertCustomer(Customers customer)
    {
        service.AddCustomer(customer);
    }

    public void UpdateCustomer(Customers customer)
    {
        service.UpdateCustomer(customer);
    }

    public void DeleteCustomer(int id)
    {
        service.DeleteCustomer(id);
    }

    public Customers FindCustomerByID(int id)
    {
        return service.GetCustomerByID(id);
    }

    public Customers FindCustomerByName(string name)
    {
        return service.GetCustomerByName(name);
    }

    public List<Customers> ListOfAllCustomers()
    {
        return service.GetAllCustomers();
    }
}
