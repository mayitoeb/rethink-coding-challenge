using Microsoft.AspNetCore.Mvc;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAsync()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }

        [HttpPut]
        public async Task<ActionResult<Patient>> PutAsync([FromBody] Patient patient)
        {
            try
            {
                await _repository.UpdateAsync(patient);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }  
        }
    }
}
