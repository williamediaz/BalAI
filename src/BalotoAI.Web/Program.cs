using BalotoAI.Infrastructure.Data;
using BalotoAI.Infrastructure.Services;
using BalotoAI.Application;
using Microsoft.EntityFrameworkCore;
using Serilog;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Add services
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BalotoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=localhost;Database=BalotoAI;Trusted_Connection=True;"));

builder.Services.AddScoped<ISimulationService, SimulationService>();
builder.Services.AddMediatR(typeof(BalotoAI.Application.Interfaces.ISimulationService).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
