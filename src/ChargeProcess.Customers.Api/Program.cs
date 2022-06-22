using ChargeProcess.Customers.Application.Commands.Customers;
using ChargeProcess.Customers.Crosscutting.DependencyInjection;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
        options.DisableDataAnnotationsValidation = true;
    });

builder.Services.AddMediator();
//builder.Services.AddLogger(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCosmos(builder.Configuration);
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
