using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Another.Models
{
    public class Uploads
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string Subject_Code { get; set; }
        public string Subject_Name { get; set; }
        public string Study_Year { get; set; }
        public string Description { get; set; }
        public string Hashtags { get; set; }
        public string file_Upload { get; set; }
    }
}
