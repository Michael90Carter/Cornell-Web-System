using Cornell_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cornell_WebAPI.Data;

/*var MyAllowSpecificorigins = "_myAllowSpecificOrigins";*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Cornell_WebAPI_DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cornell_WebAPI_DbContext") ?? throw new InvalidOperationException("Connection string 'Cornell_WebAPI_DbContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<Cornell_WebAPI_DbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Cornell_WebAPI_DbContext")));
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


app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
