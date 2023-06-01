using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true);
    });
});

builder.Services.AddOcelot();

var app = builder.Build();

app.UseCors("CorsPolicy");

await app.UseOcelot();

app.Run();
