using Microsoft.AspNetCore.Mvc;
using PneumoniaAutoDiagnosis.Models;
using PneumoniaAutoDiagnosis.Services;
using System.Collections.Generic;

namespace PneumoniaAutoDiagnosis.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly PatientService _patientService;

		public PatientController(PatientService patientService)
		{
			_patientService = patientService;
		}

        [HttpGet]
        public ActionResult<List<Patient>> Get() => _patientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPatient")]
        public ActionResult<Patient> Get(string id)
        {
            var patient = _patientService.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {
            _patientService.Create(patient);

            return CreatedAtRoute("GetBook", new { id = patient.Id.ToString() }, patient);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Patient bookIn)
        {
            var patient = _patientService.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var patient = _patientService.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Delete(patient.Id);

            return NoContent();
        }
    }
}
