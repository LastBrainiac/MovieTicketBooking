using MTBS.BasketAPI.ExtensionMethods;
using MTBS.BasketAPI.Repository;
using RabbitMQ.Client;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var multiPlexer = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiPlexer);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
    var factory = new ConnectionFactory()
    {
        HostName = builder.Configuration["EventBus:Connection"],
        DispatchConsumersAsync = true
    };

    if (!string.IsNullOrEmpty(builder.Configuration["EventBus:UserName"]))
    {
        factory.UserName = builder.Configuration["EventBus:UserName"];
    }

    if (!string.IsNullOrEmpty(builder.Configuration["EventBus:Password"]))
    {
        factory.Password = builder.Configuration["EventBus:Password"];
    }

    var retryCount = 5;
    if (!string.IsNullOrEmpty(builder.Configuration["EventBus:RetryCount"]))
    {
        retryCount = int.Parse(builder.Configuration["EventBus:RetryCount"]);
    }

    return new DefaultRabbitMQPersistentConnection(factory, retryCount);
});

builder.Services.RegisterEventBus(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
