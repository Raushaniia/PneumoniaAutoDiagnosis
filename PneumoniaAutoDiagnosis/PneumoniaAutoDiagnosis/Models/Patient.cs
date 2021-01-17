using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PneumoniaAutoDiagnosis.Models
{
	public class Patient
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public long Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public enum DiagnosisStatus { Negative, Positive, InProgress}
	}
}
