using Microsoft.VisualBasic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DashbordMangment.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string Fname { get; set; }
        public string LName { get; set; }
        public string Username { get; set; }
        
        public string Description { get; set; }
        public string DateJoin { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string birthday { get; set; }
        public string adress { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public string mariedStatus { get; set; }
        public string imageURL { get; set; }  
        public string nationality { get; set; }
        public string job { get; set; }
        public string department { get; set; }
    }
}
