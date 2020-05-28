using System.Collections.Generic;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [ApiController]
    [Route("api/Applicants")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        private readonly ILogger<ApplicantsController> _logger;

        public ApplicantsController(ILogger<ApplicantsController> logger, IApplicantService applicantService)
        {
            _logger = logger;
            _applicantService = applicantService;
        }

        [HttpGet]
        public IEnumerable<ApplicantModel> Get()
        {
            _logger.LogDebug("Index was called");
            var records = _applicantService.GetAll();

            return records;
        }

        [HttpGet("{id:int}")]
        public ApplicantModel Get(int id)
        {
            var record = _applicantService.GetById(id);

            return record;
        }

        /// <summary>
        ///     Add new Applicant
        /// </summary>
        /// ///
        /// <remarks>
        ///     Sample request:
        ///     POST api/Applicants
        ///     {
        ///     "id": 0,
        ///     "name": "suraj ayo",
        ///     "familyName": "fehintola",
        ///     "address": "11 Popoola Banjoko",
        ///     "countryOfOrigin": "Nigeria",
        ///     "eMailAddress": "surifoll@yahoo.com",
        ///     "age": 20,
        ///     "hired": true
        ///     }
        /// </remarks>
        /// <param name="applicantModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ApplicantModel applicantModel)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Fill all required Fields");

            var result = _applicantService.Add(applicantModel);

            return CreatedAtAction(nameof(Get), new {id = applicantModel.ID}, result);
        }

        [HttpPut("{id}")]
        public ActionResult<ApplicantModel> UpdateArtist(int id, [FromBody] ApplicantModel applicantModel)
        {
            if (!ModelState.IsValid) return StatusCode(400, "Fill all required Fields");
            var applicant = _applicantService.GetById(id);

            if (applicant == null)
                return NotFound();

            _applicantService.Update(id, applicantModel);
            return Ok(applicant);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(int id)
        {
            var applicant = _applicantService.GetById(id);

            if (applicant == null)
                return NotFound();

            _applicantService.Delete(id);

            return NoContent();
        }
    }
}