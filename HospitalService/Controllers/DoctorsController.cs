using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data;
using HospitalService.Models;
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
        private readonly HospitalDBContext _context;
        public DoctorsController(HospitalDBContext context)
        {
            _context = context;
        }
        // GET: api/Test
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();

            return Ok(doctors); 
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorId == id);

            return Ok(doctor);
        }

        [Route("doctors/{doctorId}/patients")]
        [HttpGet]
        public async Task<IActionResult> GetDoctorsPatients(int doctorId)
        {
            var patients = await _context.Patients
                                            .Where(x => x.Card.Records.Where(x => x.DoctorId == doctorId) != null).ToListAsync();
            return Ok(patients);
        }

        // POST: api/Test
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return Created(string.Empty, doctor);
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
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _context.Doctors.SingleAsync(x => x.DoctorId == id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return Ok(doctor);
        }
    }
}
