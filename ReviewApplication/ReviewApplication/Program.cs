using Microsoft.EntityFrameworkCore;
using ReviewApplicatio.Infrastructure;
using ReviewApplication.Application;
using ReviewApplication.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
