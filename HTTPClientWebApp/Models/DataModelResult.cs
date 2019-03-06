using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HTTPClientWebApp.Models
{
    public class DataModelResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("LinkedId")]
        public string LinkedId { get; set; }
        [BsonElement("DataResult1")]
        public double DataResult1 { get; set; }
        [BsonElement("DataResult2")]
        public string DataResult2 { get; set; }

        public DataModelResult(DataModel data)
        {
            LinkedId = data.Id;
            DataResult1 = data.Data2 * data.Data1;
            DataResult2 = data.Data3 +" "+ data.Data5.ToString();
        }

    }
}