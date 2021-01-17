using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PneumoniaAutoDiagnosis.Models
{
	public class User
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		private long Id { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public Role Role { get; set; }
	}
}
