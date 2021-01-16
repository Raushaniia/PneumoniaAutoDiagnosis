using System;

namespace PneumoniaAutoDiagnosis.Models
{
	public class Patient
	{
		private long Id { get; set; }
		public string Name { get; set; }
		public DateTime DateOfBirth { get; set; }
	}
}
