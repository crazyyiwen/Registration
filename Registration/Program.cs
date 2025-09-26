using Registration.models;
using Microsoft.EntityFrameworkCore;
using Registration.data;

var builder = WebApplication.CreateBuilder (args);

builder.Services.AddControllers ( );
builder.Services.AddEndpointsApiExplorer ( );
builder.Services.AddSwaggerGen ( );

// Connect to your existing DB
builder.Services.AddDbContext<AlarmUserDbContext> (options =>
    options.UseSqlServer (builder.Configuration.GetConnectionString ("DefaultConnection")));

var app = builder.Build ( );

if (app.Environment.IsDevelopment ( ))
{
    app.UseSwagger ( );
    app.UseSwaggerUI ( );
}

app.UseHttpsRedirection ( );
app.UseAuthorization ( );
app.MapControllers ( );
app.Run ( );
