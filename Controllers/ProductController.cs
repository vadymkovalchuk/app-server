using Microsoft.AspNetCore.Mvc;

[Produces("application/json")]
public class ProductController : ControllerBase
{
    [HttpGet("/products")]
    public IActionResult Get()
    {
        return Ok(TempDataStore.GetProducts());
    }
}