using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineTes.Models;
using CineTes.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CineTes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CineTESController : ControllerBase
    {
        private readonly ApiContext _context;

        public CineTESController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/CineTES
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cine>>> GetCines()
        {
            return await _context.Cines.ToListAsync();
        }

        // GET: api/CineTES/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cine>> GetCine(int id)
        {
            var Cine = await _context.Cines.FindAsync(id);

            if (Cine == null)
            {
                return NotFound();
            }

            return Cine;
        }

        // POST: api/CineTES
        [HttpPost]
        public async Task<ActionResult<Cine>> PostCine([FromBody] Cine Cine)
        {
            // Asegúrate de que el nuevo cine tenga un ID válido
            Cine.Id = 0;

            _context.Cines.Add(Cine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCine), new { id = Cine.Id }, Cine);
        }

        // PUT: api/CineTES/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCine(int id, [FromBody] Cine Cine)
        {
            if (id != Cine.Id)
            {
                return BadRequest();
            }

            _context.Entry(Cine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CineExists(id))
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

        // DELETE: api/CineTES/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCine(int id)
        {
            var Cine = await _context.Cines.FindAsync(id);
            if (Cine == null)
            {
                return NotFound();
            }

            _context.Cines.Remove(Cine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CineExists(int id)
        {
            return _context.Cines.Any(e => e.Id == id);
        }
    }
}