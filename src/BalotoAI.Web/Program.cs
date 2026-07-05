using BalotoAI.Infrastructure.Repositories;
using BalotoAI.Infrastructure.Services;
using BalotoAI.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using BalotoAI.Infrastructure.Data;
using BalotoAI.Domain.Repositories;

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

// Application / Infrastructure registrations
builder.Services.AddScoped<ISimulationService, SimulationService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<IDrawRepository, DrawRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// MediatR
builder.Services.AddMediatR(typeof(BalotoAI.Application.Interfaces.ISimulationService).Assembly);

// FluentValidation and pipeline
builder.Services.AddValidatorsFromAssemblyContaining<BalotoAI.Application.Validators.CreateDrawValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
