
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;

namespace DashbordMangment.Models
{
	public class Applicant
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ID { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string message { get; set; }
        public int Phone { get; set; }
		public string CvPath { get; set; }
		[BsonIgnore]
		public IFormFile Cv { get; set; }


	}
}
