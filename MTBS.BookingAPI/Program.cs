using Microsoft.EntityFrameworkCore;
using MTBS.BookingAPI.DbContexts;
using MTBS.BookingAPI.EventBusIntegration.Consumer;
using MTBS.BookingAPI.Repositories;
using MTBS.EventBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<APIDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var optionBuilder = new DbContextOptionsBuilder<APIDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new BookingRepository(optionBuilder.Options));

builder.Services.AddSingleton(new RabbitMQConsumer(builder.Configuration));

builder.Services.AddSingleton<IRabbitMQMessageSender, RabbitMQMessageSender>();
builder.Services.AddSingleton(new RabbitMQMessageSender(builder.Configuration));

builder.Services.AddHostedService<RabbitMQBookingConsumer>();

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
