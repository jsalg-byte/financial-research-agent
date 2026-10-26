using FinancialResearchAgent.Api.Models;

namespace FinancialResearchAgent.Api.Repositories;

public class InMemoryFinancialRecordRepository : IFinancialRecordRepository
  {
    private readonly List<FinancialRecord> _records = new();

    //todo-
    
    //Add
    public FinancialRecord Add(FinancialRecord record)
    {
      _records.Add(record);
      if (_records.Count > 0){
        return _records[_records.Count - 1];
      }
      //better error handling later
      //to do error handle
      FinancialRecord record1 = record;
      record1.Id = -1;
      return record1;

    }
    //GetById
    public FinancialRecord GetById(int id)
    {
      FinancialRecord record = _records.Find( record => record.Id == id);
        return record;
    }
    //GetAll
    public IEnumerable<FinancialRecord> GetAll()
    {
      return _records.FindAll(record => record.Id >= 1);
    }
    //Delete
    public bool Delete(int id)
    {
      int recordIdx = _records.FindIndex(record => record.Id == id);
      if(recordIdx == -1){return false;}
      _records.RemoveAt(recordIdx);
      int success = _records.FindIndex(record => record.Id == id);
      if(success == -1){
        return true;
      }
      return false;
    }
    //Update
    public bool Update(FinancialRecord record)
    {
      int recordIdx = _records.FindIndex(savedRecord => savedRecord.Id == record.Id);
      if(recordIdx != -1)
      {
        _records[recordIdx] = record;
        if(_records[recordIdx] != record){return false;}
        return true;
      }
      return false;
    }
    //Replace
    public bool Replace(FinancialRecord record)
    {
      int recordIdx = _records.FindIndex(savedRecord => savedRecord.Id == record.Id);
      if(recordIdx != -1)
      {
        _records[recordIdx] = record;
        if(_records[recordIdx] != record){return false;}
        return true;
      }
      return false;
    }
  }
