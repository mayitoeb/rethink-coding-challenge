using MediatR;
using Microsoft.AspNetCore.Mvc;
using webapi.Core.Commands;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ISender _mediator;
        private readonly IPatientRepository _repository;

        public PatientsController(ILogger<PatientsController> logger, ISender mediator,IPatientRepository repository)
        {
            _logger = logger;
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllAsync()
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
        public async Task<ActionResult<Patient>> PutAsync([FromBody] UpdatePatientCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating patient {patient}.", command);
                return StatusCode(500, "There was an error updating the patient.");
            }  
        }
    }
}
