﻿using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using webapi.Core.Domain;
using webapi.Core.Interfaces;

namespace webapi.Controllers
{
    [Route("file-upload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        const string permittedExtension = ".csv";
        private readonly ILogger _logger;
        private readonly IPatientRepository _repository;
        

        public FileUploadController(ILogger<FileUploadController> logger, IPatientRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            try
            {
                var form = Request.Form;

                if (form == null || form.Files.Count == 0)
                {
                    return BadRequest("File not uploaded.");
                }

                var file = form.Files[0];

                if (!file.FileName.Contains(permittedExtension))
                {
                    return BadRequest("Extension is not valid.");
                }

                using (var stream = file.OpenReadStream())
                using (var streamReader = new StreamReader(stream))
                {
                    var map = new PatientMap();
                    var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture);
                    csv.Context.RegisterClassMap(map);
                    var patients = csv.GetRecords<Patient>();
                    await _repository.AddAsync(patients);
                };

                return Ok();
            }
            catch (CsvHelperException ex)
            {
                _logger.LogError(ex, "Wrong Csv format.");
                return BadRequest("Csv is not formatted properly.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file.");
                return StatusCode(500, "There was an error uploading the file.");
            }
        }
    }
}
