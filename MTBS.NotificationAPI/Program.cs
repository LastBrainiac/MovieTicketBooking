using Microsoft.EntityFrameworkCore;
using MTBS.EventBus;
using MTBS.NotificationAPI.DbContexts;
using MTBS.NotificationAPI.EventBusIntegration.Consumer;
using MTBS.NotificationAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<APIDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();

var optionBuilder = new DbContextOptionsBuilder<APIDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new NotificationRepository(optionBuilder.Options));

builder.Services.AddSingleton(new RabbitMQConsumer(builder.Configuration));

builder.Services.AddHostedService<RabbitMQEmailConsumer>();

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
