using MTBS.BasketAPI.Repository;
using MTBS.EventBus;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var multiPlexer = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiPlexer);

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
builder.Services.AddSingleton(new RabbitMQMessageSender(builder.Configuration));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
