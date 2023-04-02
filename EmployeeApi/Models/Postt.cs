using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EmployeeApi.Models
{
	public class Postt
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
        public string Designation { get; set; }
        public Departement   departement { get; set; }   
    }
}
