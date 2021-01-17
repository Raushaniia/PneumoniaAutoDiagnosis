using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;

namespace PneumoniaAutoDiagnosis.Models
{
	public class PatientCard
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		private long Id { get; set; }
		public long PatientId { get; set; }
		public Image XRayImage { get; set; }
		public string Details { get; set; }
	}
}
