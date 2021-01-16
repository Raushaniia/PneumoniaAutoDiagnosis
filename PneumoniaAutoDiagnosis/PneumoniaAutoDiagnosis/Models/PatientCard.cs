using System.Drawing;

namespace PneumoniaAutoDiagnosis.Models
{
	public class PatientCard
	{
		private long Id { get; set; }
		public long PatientId { get; set; }
		public Image XRayImage { get; set; }
		public string Details { get; set; }
	}
}
