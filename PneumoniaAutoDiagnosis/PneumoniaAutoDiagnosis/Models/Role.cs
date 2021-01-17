using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PneumoniaAutoDiagnosis.Models
{
	public class Role
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		private int Id { get; set; }
		public enum RoleType 
		{
			Administrator,
			User
		}
	}
}
