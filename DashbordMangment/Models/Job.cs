using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DashbordMangment.Models
{
	public class Job
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string title { get; set; }
		public string subtitle { get; set; }
		public string description { get; set; }
		public string PostDate { get; set; }
		public string lastdate { get; set; }
		public string salary { get; set; }
		public int vacancy { get; set; }
		public string location { get; set; }
		public int experience { get; set; }
		public string JobType { get; set; }
	}
}
