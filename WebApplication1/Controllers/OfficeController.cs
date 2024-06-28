using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly UserScaffoldV2Context _context;

        public OfficeController(UserScaffoldV2Context context)
        {
            _context = context;
        }

        // GET: api/Techno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MstOffice>>> GetTechnos()
        {
            return await _context.MstOffice.ToListAsync();
        }

        // GET: api/Techno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MstOffice>> GetTechno(int id)
        {
            var techno = await _context.MstOffice.FindAsync(id);

            if (techno == null)
            {
                return NotFound();
            }

            return techno;
        }

        // PUT: api/Techno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechno(int id, MstOffice office)
        {
            if (id != office.Id)
            {
                return BadRequest();
            }

            _context.Entry(office).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnoExists(id))
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

        // POST: api/Techno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MstOffice>> PostTechno(MstOffice office)
        {
            _context.MstOffice.Add(office);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechno", new { id = office.Id }, office);
        }

        // DELETE: api/Techno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechno(int id)
        {
            var techno = await _context.MstOffice.FindAsync(id);
            if (techno == null)
            {
                return NotFound();
            }

            _context.MstOffice.Remove(techno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnoExists(int id)
        {
            return _context.MstOffice.Any(e => e.Id == id);
        }

    }
}
