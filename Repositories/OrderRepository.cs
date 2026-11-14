using NHibernate;
using OrdersApi.Entities;

namespace OrdersApi.Repositories;

public class OrderRepository
{
    private readonly ISession _session;
    public OrderRepository(ISession session) => _session = session;

    public Order? Get(int id) => _session.Get<Order>(id);

    public IList<Order> ByCustomerSafe(string customer) =>
        _session.CreateQuery("from Order o where o.Customer = :c")
                .SetParameter("c", customer)
                .List<Order>();

    public IList<Order> ByCustomer(string customer)
    {
        var sql = "SELECT * FROM Orders WHERE Customer = '" + customer + "'";
        return _session.CreateSQLQuery(sql).AddEntity(typeof(Order)).List<Order>();
    }
}
