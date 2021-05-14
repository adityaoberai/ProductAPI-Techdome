using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemDetailsController : ControllerBase
    {
        private readonly ProblemDetailsContext _context;

        public ProblemDetailsController(ProblemDetailsContext context)
        {
            _context = context;
        }

        // GET: api/ProblemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.ProblemDetails>>> GetProblemDetailsList()
        {
            return await _context.ProblemDetails.ToListAsync();
        }

        // GET: api/ProblemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.ProblemDetails>> GetProblemDetails(int id)
        {
            var problemDetails = await _context.ProblemDetails.FindAsync(id);

            if (problemDetails == null)
            {
                return NotFound();
            }

            return problemDetails;
        }

        // PUT: api/ProblemDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblemDetails(int id, Models.ProblemDetails problemDetails)
        {
            if (id != problemDetails.status)
            {
                return BadRequest();
            }

            _context.Entry(problemDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProblemDetailsExists(id))
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

        // POST: api/ProblemDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.ProblemDetails>> PostProblemDetails(Models.ProblemDetails problemDetails)
        {
            _context.ProblemDetails.Add(problemDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProblemDetails", new { id = problemDetails.status }, problemDetails);
        }

        // DELETE: api/ProblemDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblemDetails(int id)
        {
            var problemDetails = await _context.ProblemDetails.FindAsync(id);
            if (problemDetails == null)
            {
                return NotFound();
            }

            _context.ProblemDetails.Remove(problemDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProblemDetailsExists(int id)
        {
            return _context.ProblemDetails.Any(e => e.status == id);
        }
    }
}
