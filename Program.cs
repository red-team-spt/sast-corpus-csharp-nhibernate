using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OrdersApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<ISessionFactory>(_ =>
    Fluently.Configure()
        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(builder.Configuration["Db:Connection"]))
        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
        .BuildSessionFactory());
builder.Services.AddScoped(sp => sp.GetRequiredService<ISessionFactory>().OpenSession());
builder.Services.AddSingleton<SigningService>();

var app = builder.Build();
app.MapControllers();
app.Run();
