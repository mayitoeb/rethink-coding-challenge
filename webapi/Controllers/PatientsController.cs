using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPatientRepository _repository;

        public PatientsController(ILogger<PatientsController> logger, IPatientRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting the patients.");
                return StatusCode(500, "There was an error getting the patients.");
            }
          
        }

        [HttpPut]
        public async Task<ActionResult<Patient>> PutAsync([FromBody] Patient patient)
        {
            try
            {
                await _repository.UpdateAsync(patient);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating patient {patient}.", patient);
                return StatusCode(500, "There was an error updating the patient.");
            }  
        }
    }
}
