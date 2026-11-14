using FluentNHibernate.Mapping;

namespace OrdersApi.Entities;

public class Order
{
    public virtual int Id { get; set; }
    public virtual string Customer { get; set; } = "";
    public virtual decimal Total { get; set; }
}

public class OrderMap : ClassMap<Order>
{
    public OrderMap()
    {
        Id(x => x.Id);
        Map(x => x.Customer);
        Map(x => x.Total);
    }
}
