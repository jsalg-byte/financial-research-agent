using FinancialResearchAgent.Api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//minimal endpoints
app.MapGet("api/financial-records", () => 
      new FinancialRecord {
        //dummy obj
        Id = 1,
        Company = "Apple",
        Metric = "Stock",
        Value = 348,
        Unit = "USD",
        FiscalYear = DateTime.Now.Year
      }
    );

app.Run();
