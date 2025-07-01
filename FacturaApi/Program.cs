using FacturaApi.Data;
using FacturaApi.Repositories;
using FacturaApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FacturaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DesarrolloLibre", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<FacturaService>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();


var app = builder.Build();



app.UseCors("DesarrolloLibre");
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};



////app.MapGet("/weatherforecast", () =>
////{
////    var forecast =  Enumerable.Range(1, 5).Select(index =>
////        new WeatherForecast
////        (
////            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
////            Random.Shared.Next(-20, 55),
////            summaries[Random.Shared.Next(summaries.Length)]
////        ))
////        .ToArray();
////    return forecast;
////})
////.WithName("GetWeatherForecast")
////.WithOpenApi();
///
app.UseRouting();
app.MapControllers();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
