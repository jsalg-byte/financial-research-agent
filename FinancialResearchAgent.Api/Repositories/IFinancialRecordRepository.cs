using FinancialResearchAgent.Api.Models;

namespace FinancialResearchAgent.Api.Repositories;

public interface IFinancialRecordRepository
{
  //type we r dealing with: <FinancialRecord>
  //all http methods : CREATE, GET by ID, GET all, PUT, PATCH, DELETE
  //CREATE 
  FinancialRecord Add(FinancialRecord record);
  //Get by ID
  FinancialRecord? GetById(int id);
  //Get All
  IEnumerable<FinancialRecord>? GetAll();
  //Replace - Put
  bool Replace(FinancialRecord record);
  //Update - Patch
  bool Update(FinancialRecord record);
  //DLETE
  bool Delete(int id);
}
