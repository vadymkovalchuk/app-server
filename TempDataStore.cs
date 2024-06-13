// no race condition safety, no data integrity checking - only for demo purposes
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

public class TempDataStore
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "John", "Doe", "Smith"),
        new Employee(2, "Jane", "Doe", "Smith"),
        new Employee(3, "Jim", "Doe", "Smith"),
        new Employee(4, "Jill", "Doe", "Smith"),
    };
    private static List<Product> products = new List<Product>()
    {
        new Product(1, "Ergonomic Keyboard", 49.95f),
        new Product(2, "Ergonomic Mouse", 25.78f),
        new Product(3, "Docking Station", 250.00f),
        new Product(4, "Power Supply", 123.14f),
    };    
    private static List<Customer> customers = new List<Customer>();
    private static List<Order> orders = new List<Order>();

    public static IEnumerable<Employee> GetEmployees() => employees;
    public static IEnumerable<Product> GetProducts() => products;

    public static IEnumerable<Customer> GetCustomers() => customers;

    public static Customer CreateCustomer(Customer customer)
    {
        int maxId = customers.Any() ? customers.Max(c => c.CustomerID) : 0;
        var newCustomer = new Customer(maxId + 1, customer.FirstName, customer.MiddleName, customer.LastName);
        customers.Add(newCustomer);
        return newCustomer;
    }
    public static Customer UpdateCustomer(Customer customer)
    {
        // needs error handling, race condition handling
        var existingCustomer = customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);
        if (existingCustomer != null)
        {
            customers.Remove(existingCustomer);
            customers.Add(customer);
            return customer;
        }
        throw new Exception("Can't find id to update.");
    }
    public static Customer DeleteCustomer(int customerID)
    {
        // needs error handling, protection against deleting customers who have orders
        var customer = customers.FirstOrDefault(c => c.CustomerID == customerID);
        customers.RemoveAll(c => c.CustomerID == customerID);
        return customer!;
    }

    public static IEnumerable<Order> GetCustomerOrders(int customerID)
    {
        return orders.Where(o => o.CustomerID == customerID);
    }
    public static Order AddCustomerOrder(Order order)
    {
        int maxId = orders.Any() ? orders.Max(c => c.OrderID) : 0;
        var newCustomerOrder = new Order(maxId + 1, order.SalesPersonID, order.CustomerID, order.ProductID, order.Quantity);
        orders.Add(newCustomerOrder);
        return newCustomerOrder;
    }
}
