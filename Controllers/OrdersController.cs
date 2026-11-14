using Microsoft.AspNetCore.Mvc;
using NHibernate;
using OrdersApi.Repositories;

namespace OrdersApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrderRepository _repo;
    public OrdersController(ISession session) => _repo = new OrderRepository(session);

    [HttpGet("{id:int}")]
    public IActionResult Get(int id) => _repo.Get(id) is { } o ? Ok(o) : NotFound();

    [HttpGet]
    public IActionResult ByCustomer([FromQuery] string customer) => Ok(_repo.ByCustomer(customer));
}
