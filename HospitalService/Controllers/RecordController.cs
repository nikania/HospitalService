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
    public class RecordController : ControllerBase
    {
        private readonly HospitalDBContext _context;

        public RecordController(HospitalDBContext context)
        {
            _context = context;
        }
        // GET: api/Record
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Cards = await _context.Records.ToListAsync();
            return Ok(Cards);
        }

        // GET: api/Record/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var Record = await _context.Records.SingleOrDefaultAsync(x => x.CardId == id);
            return Ok(Record);
        }

        // POST: api/Card
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            return CreatedAtAction("post", record);
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Record record)
        {
            _context.Records.Update(record);
            await _context.SaveChangesAsync();
            return Ok(record);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.Records.SingleOrDefaultAsync(x => x.RecordId == id);
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();
            return Ok(record);
        }
    }
}
