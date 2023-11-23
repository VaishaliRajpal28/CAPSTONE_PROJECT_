using Capstone.Models;
using MongoDB.Driver;
using Capstone.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<LocationStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(LocationStoreDatabaseSettings)));




builder.Services.AddSingleton<ILocationStoreDatabaseSettings>(
    sp => sp.GetRequiredService<IOptions<LocationStoreDatabaseSettings>>().Value);


builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("LocationStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ILocationService, LocationService>();


  







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




app.UseCors(options =>
        options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
