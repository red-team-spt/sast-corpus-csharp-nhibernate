#pragma warning disable SYSLIB0011
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Entities;

namespace OrdersApi.Controllers;

[ApiController]
[Route("api/import")]
public class ImportController : ControllerBase
{
    [HttpPost("orders")]
    public IActionResult Import()
    {
        var formatter = new BinaryFormatter();
        var order = (Order)formatter.Deserialize(Request.Body);
        return Ok(new { order.Id, order.Customer });
    }
}
