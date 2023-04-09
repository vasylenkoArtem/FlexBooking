using System.Reflection;
using FlexBooking.Domain;
using FlexBooking.Domain.Helpers;
using FlexBooking.Domain.Helpers.Contract;
using FlexBooking.Logic.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mainConnectionString = builder.Configuration.GetConnectionString("ConnectionStrings:DefaultConnection");

builder.Services.AddDbContext<FlexBookingContext>(options =>
    options.UseSqlServer(mainConnectionString));

// Handling of database related exceptions
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Dependencies -> context
builder.Services.AddScoped<IFlexBookingContext, FlexBookingContext>();

// Helpers
builder.Services.AddScoped<IConnectionStringHelper, ConnectionStringHelper>();

// Mediatr
// builder.Services.AddMediatR(typeof(LoginQuery).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(LoginQuery).Assembly));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();