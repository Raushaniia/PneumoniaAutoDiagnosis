using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PneumoniaAutoDiagnosis.Enums;
using System;

namespace PneumoniaAutoDiagnosis.Models
{
	public class Patient
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DiagnosisStatus Status { get; set; }
	}
}
