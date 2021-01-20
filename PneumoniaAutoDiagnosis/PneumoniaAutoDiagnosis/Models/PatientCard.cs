using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;

namespace PneumoniaAutoDiagnosis.Models
{
	public class PatientCard
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonRepresentation(BsonType.ObjectId)]
		public string PatientId { get; set; }
		public Image XRayImage { get; set; }
		public string Details { get; set; }
	}
}
