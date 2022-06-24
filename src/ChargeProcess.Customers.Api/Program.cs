using ChargeProcess.Customers.Application.Commands.Customers;
using ChargeProcess.Customers.Application.Queries.GetCustomerBydocument;
using ChargeProcess.Customers.Crosscutting.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

LoggerServiceCollectionExtension.AddLogger(builder.Configuration);

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddFluentValidation();

builder.Services.AddScoped<IValidator<CustomerRequest>, CustomerValidator>();
builder.Services.AddScoped<IValidator<string>, GetCustomerByDocumentValidator>();

builder.Services.AddMediator();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCosmos(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
