using Azure.Messaging.ServiceBus;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration["ServiceBus:ConnectionString"];

if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddSingleton(new ServiceBusClient(connectionString));
}

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
builder.Services.AddHealthChecks();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();
app.UseCors("AllowAll");
app.MapControllers();
app.MapHealthChecks("/health");
app.Run();