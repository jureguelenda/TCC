using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2._0.Data;
using TCC_2._0.Models;

namespace TCC_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITENSENTRADAsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ITENSENTRADAsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ITENSENTRADAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ITENSENTRADA>>> GetITENSENTRADA()
        {
            return await _context.ITENSENTRADA.ToListAsync();
        }

        // GET: api/ITENSENTRADAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ITENSENTRADA>> GetITENSENTRADA(int id)
        {
            var iTENSENTRADA = await _context.ITENSENTRADA.FindAsync(id);

            if (iTENSENTRADA == null)
            {
                return NotFound();
            }

            return iTENSENTRADA;
        }

        // PUT: api/ITENSENTRADAs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutITENSENTRADA(int id, ITENSENTRADA iTENSENTRADA)
        {
            if (id != iTENSENTRADA.ITEID)
            {
                return BadRequest();
            }

            _context.Entry(iTENSENTRADA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ITENSENTRADAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ITENSENTRADAs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ITENSENTRADA>> PostITENSENTRADA(ITENSENTRADA iTENSENTRADA)
        {
            _context.ITENSENTRADA.Add(iTENSENTRADA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetITENSENTRADA", new { id = iTENSENTRADA.ITEID }, iTENSENTRADA);
        }

        // DELETE: api/ITENSENTRADAs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteITENSENTRADA(int id)
        {
            var iTENSENTRADA = await _context.ITENSENTRADA.FindAsync(id);
            if (iTENSENTRADA == null)
            {
                return NotFound();
            }

            _context.ITENSENTRADA.Remove(iTENSENTRADA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ITENSENTRADAExists(int id)
        {
            return _context.ITENSENTRADA.Any(e => e.ITEID == id);
        }
    }
}
