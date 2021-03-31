using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PneumoniaAutoDiagnosis.Models;
using PneumoniaAutoDiagnosis.Services;
using System.Collections.Generic;

namespace PneumoniaAutoDiagnosis.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientCardController : ControllerBase
    {
        private readonly PatientCardService _patientCardService;

        public PatientCardController(PatientCardService PatientCardService)
        {
            _patientCardService = PatientCardService;
        }

        [HttpGet]
        public ActionResult<List<PatientCard>> Get() => _patientCardService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPatientCard")]
        public ActionResult<PatientCard> Get(string id)
        {
            var PatientCard = _patientCardService.Get(id);

            if (PatientCard == null)
            {
                return NotFound();
            }

            return PatientCard;
        }

        [HttpPost]
        public ActionResult<PatientCard> Create(PatientCard PatientCard)
        {
            _patientCardService.Create(PatientCard);

            return CreatedAtRoute("Get", new { id = PatientCard.Id.ToString() }, PatientCard);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, PatientCard bookIn)
        {
            var PatientCard = _patientCardService.Get(id);

            if (PatientCard == null)
            {
                return NotFound();
            }

            _patientCardService.Update(id, bookIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var PatientCard = _patientCardService.Get(id);

            if (PatientCard == null)
            {
                return NotFound();
            }

            _patientCardService.Delete(PatientCard.Id);

            return NoContent();
        }
    }
}
