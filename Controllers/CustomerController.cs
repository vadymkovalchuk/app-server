using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
public class CustomerController : ControllerBase
{
    [HttpGet("/customers")]
    public IActionResult Get()
    {
        return Ok(TempDataStore.GetCustomers());
    }

    [HttpPost("/customer")]
    public IActionResult New([FromBody]Customer customer)
    {
        return Ok(TempDataStore.CreateCustomer(customer));
    }
    
    [HttpPut("/customer")]
    public IActionResult Update([FromBody]Customer customer)
    {
        return Ok(TempDataStore.UpdateCustomer(customer));
    }
    
    [HttpDelete("/customer/{customerID}")]
    public IActionResult Delete(int customerID)
    {
        return Ok(TempDataStore.DeleteCustomer(customerID));
    }
  
    [HttpGet("/customer/{customerID}/orders")]
    public IActionResult GetOrders(int customerID)
    {
        return Ok(TempDataStore.GetCustomerOrders(customerID));
    }

    [HttpPost("/order")]
    public IActionResult AddOrder([FromBody]Order order)
    {
        return Ok(TempDataStore.AddCustomerOrder(order));
    }
}
