using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalService.Data;
using HospitalService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HospitalDBContext _context;

        public PatientController(HospitalDBContext context)
        {
            _context = context;
        }
        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var patients = await _context.Patients.ToArrayAsync();
            return  Ok(patients);
        }

        // GET: api/Patient/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(x => x.PatientId == id);
            return Ok(patient);
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction("post",patient);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.Patients.SingleOrDefaultAsync(x => x.PatientId == id);
            _context.Patients.Remove(patient);
            return Ok(patient);
        }
    }
}
