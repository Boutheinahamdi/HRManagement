using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DashbordMangment.Models
{
    public class Project
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string Deadline { get; set; }
        public int progress { get; set; }
        public List<string> employe { get; set; }
        public List<string> tasks { get; set; }
    }
}
