using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class CardController : ControllerBase
    {
        private readonly HospitalDBContext _context;

        public CardController(HospitalDBContext context)
        {
            _context = context;
        }
        // GET: api/Card
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Cards = await _context.Cards.ToListAsync();
            return Ok(Cards);
        }

        // GET: api/Card/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var Card = await _context.Cards.SingleOrDefaultAsync(x => x.CardId == id);
            return Ok(Card);
        }

        // POST: api/Card
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return CreatedAtAction("post",card);
        }

        // PUT: api/Card/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
            return Ok(card);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _context.Cards.SingleOrDefaultAsync(x => x.CardId == id);
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return Ok(card);
        }
    }
}
