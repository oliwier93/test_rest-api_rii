using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Dodaj serwisy do kontenera DI
builder.Services.AddSingleton<IRegistryNumberGenerator, RegistryNumberGenerator>();
builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // Upewnij się, że kontrolery są mapowane

app.Run();
