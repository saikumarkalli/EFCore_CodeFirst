using EFCore_CodeFirst.Context;
using EFCore_CodeFirst.Services.EmployeeService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//PostgreSql
//builder.Services.AddDbContext<DataContext>(x => x.UseNpgsql("Server=localhost;Database=Pratice;Port=5433;UserId=postgres;Password=sa@123;Trust Server Certificate=true;Integrated Security=true"));

//SQL
//builder.Services.AddDbContext<DataContext>(options =>
//{
//    options.UseSqlServer("Data Source=L201412;Initial Catalog=Pratice;Integrated Security=True;TrustServerCertificate=True");
//});


//DI for Services...
builder.Services.AddScoped<IEmployeeService, EmployeeService>();



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
