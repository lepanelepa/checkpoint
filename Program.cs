using CheckPoint.Interfaces;
using CheckPoint.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<ICarRepository, CarService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
