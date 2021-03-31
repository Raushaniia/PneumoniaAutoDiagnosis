﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PneumoniaAutoDiagnosis.Enums;

namespace PneumoniaAutoDiagnosis.Models
{
	public class User
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		
		public RoleType Role { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
	}
}
