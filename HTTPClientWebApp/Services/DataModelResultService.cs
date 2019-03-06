using System.Collections.Generic;
using System.Linq;
using HTTPClientWebApp.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace HTTPClientWebApp.Services
{
    public class DataModelResultService
    {
        private readonly IMongoCollection<DataModelResult> _DataModelResults;

        public DataModelResultService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Database"));
            var database = client.GetDatabase("Database");
            _DataModelResults = database.GetCollection<DataModelResult>("DataModelResult");
        }

        public List<DataModelResult> Get()
        {
            return _DataModelResults.Find(DataModelResult => true).ToList();
        }

        public DataModelResult Get(string id)
        {
            return _DataModelResults.Find<DataModelResult>(DataModelResult => DataModelResult.Id == id).FirstOrDefault();
        }

        public DataModelResult Create(DataModelResult DataModelResult)
        {
            _DataModelResults.InsertOne(DataModelResult);
            return DataModelResult;
        }

        public void Update(string id, DataModelResult DataModelResultIn)
        {
            _DataModelResults.ReplaceOne(DataModelResult => DataModelResult.Id == id, DataModelResultIn);
        }

        public void Remove(DataModelResult DataModelResultIn)
        {
            _DataModelResults.DeleteOne(DataModelResult => DataModelResult.Id == DataModelResultIn.Id);
        }

        public void Remove(string id)
        {
            _DataModelResults.DeleteOne(DataModelResult => DataModelResult.Id == id);
        }

    }
}