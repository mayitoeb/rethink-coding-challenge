using Microsoft.AspNetCore.Mvc;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientReadRepository _repository;

        public PatientsController(IPatientReadRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAsync()
        {
            var data = await _repository.GetAllAsync();
            return Ok(data);
        }
    }
}
