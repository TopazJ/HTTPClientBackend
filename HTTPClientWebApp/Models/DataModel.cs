using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTPClientWebApp.Models
{
    public class DataModel
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Data1")]
        public int Data1 { get; set; }
        [BsonElement("Data2")]
        public double Data2 { get; set; }
        [BsonElement("Data3")]
        public string Data3 { get; set; }
        [BsonElement("Data4")]
        public Boolean Data4 { get; set; }
        [BsonElement("Data5")]
        public int Data5 { get; set; }

        public DataModel(int field1, double field2, string field3, Boolean field4, int field5)
        {
            Data1 = field1;
            Data2 = field2;
            Data3 = field3;
            Data4 = field4;
            Data5 = field5;
        }

    }
}