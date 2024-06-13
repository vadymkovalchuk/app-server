using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
public class EmployeeController : ControllerBase
{
    [HttpGet("/employees")]
    public IActionResult Get()
    {
        return Ok(TempDataStore.GetEmployees());
    }
}