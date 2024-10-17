using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Repositories;
using EmployeeManagement.Domain.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRegistryNumberGenerator, RegistryNumberGenerator>();
builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeHandler).Assembly));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
