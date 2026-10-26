using FinancialResearchAgent.Api.Models;
using FinancialResearchAgent.Api.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//add the repository as a service
builder.Services.AddSingleton<IFinancialRecordRepository, InMemoryFinancialRecordRepository>();

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
//
//basic index route
app.MapGet("/", (IFinancialRecordRepository repository) => {
      return repository.GetAll();
    });


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
