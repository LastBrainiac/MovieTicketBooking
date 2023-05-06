using Microsoft.EntityFrameworkCore;
using MTBS.EventBus;
using MTBS.NotificationAPI.DbContexts;
using MTBS.NotificationAPI.EventBusIntegration.Consumer;
using MTBS.NotificationAPI.Extensions;
using MTBS.NotificationAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<APIDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var optionBuilder = new DbContextOptionsBuilder<APIDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new NotificationRepository(optionBuilder.Options));

builder.Services.AddSingleton(new RabbitMQConsumer(builder.Configuration));
builder.Services.AddHostedService<RabbitMQEmailConsumer>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseAutoMigration();

app.Run();
