namespace FinancialResearchAgent.Api.Models;

public class FinancialRecord
{
  public int Id { get; set; }
  public string? Company { get; set; }
  public string? Metric { get; set; }
  public int? Value { get; set; }
  public string? Unit { get; set; }
  public int? FiscalYear { get; set; }
}
