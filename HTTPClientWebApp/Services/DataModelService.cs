using System.Collections.Generic;
using System.Linq;
using HTTPClientWebApp.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace HTTPClientWebApp.Services
{
    public class DataModelService
    {
        private readonly IMongoCollection<DataModel> _DataModels;

        public DataModelService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("Database"));
            var database = client.GetDatabase("Database");
            _DataModels = database.GetCollection<DataModel>("DataModel");
        }

        public List<DataModel> Get()
        {
            return _DataModels.Find(DataModel => true).ToList();
        }

        public DataModel Get(string id)
        {
            return _DataModels.Find<DataModel>(DataModel => DataModel.Id == id).FirstOrDefault();
        }

        public DataModel Create(DataModel DataModel)
        {
            _DataModels.InsertOne(DataModel);
            return DataModel;
        }

        public void Update(string id, DataModel DataModelIn)
        {
            _DataModels.ReplaceOne(DataModel => DataModel.Id == id, DataModelIn);
        }

        public void Remove(DataModel DataModelIn)
        {
            _DataModels.DeleteOne(DataModel => DataModel.Id == DataModelIn.Id);
        }

        public void Remove(string id)
        {
            _DataModels.DeleteOne(DataModel => DataModel.Id == id);
        }

    }
}