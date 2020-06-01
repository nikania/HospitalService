using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data;
using HospitalService.Models;
using HospitalService.Services;
//using LinqToDB;
//using LinqToDB;
//using LinqToDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }
        // GET: api/Test
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _service.GetDoctors();

            return Ok(doctors); 
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _service.GetDoctor(id);

            return Ok(doctor);
        }

        [Route("doctors/{doctorId}/patients")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorsPatients(int doctorId)
        {
            var patients = await _service.GetDoctorPatients(doctorId);
            return Ok(patients);
        }

        // POST: api/Test
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            var createdDoctor = await _service.CreateDoctor(doctor);
            return Created(string.Empty, createdDoctor);
        }

        //[HttpPost("test")]

        //public string Post([FromBody] string value)
        //{
        //    return value + "!!!!";
        //}

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            var changedDoctor = await _service.ChangeDoctor(doctor);
            return Ok(changedDoctor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _service.DeleteDoctor(id);
            return Ok(doctor);
        }
    }
}
