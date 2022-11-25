using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectN.Models;
using System.Net.Http;
using System.Web;
using System.Net;

namespace ProjectN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunkopopsController : ControllerBase
    {
        private readonly FunkoDBConext _context;

        public FunkopopsController(FunkoDBConext context)
        {
            _context = context;
        }

        // GET: api/Funkopops
        /**
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funkopop>>> GetFunkopop()
        {
            return await _context.Funkopop.ToListAsync();
        }
        **/
        // GET: api/Funkopops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funkopop>> GetFunkopop(int id)
        {
            var funkopop = await _context.Funkopop.Include(c => c.EstValue).FirstOrDefaultAsync(c => c.FunkoId == id);
            try
            {
                if (funkopop == null)
                {
                    throw new Exception("Not Found");
                }
                return StatusCode(200, funkopop);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
         }

        // PUT: api/Funkopops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /**[HttpPut("{id}")]
        public async Task<IActionResult> PutFunkopop(int id, Funkopop funkopop)
        {
            if (id != funkopop.FunkoId)
            {
                return BadRequest();
            }

            _context.Entry(funkopop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunkopopExists(id))
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
        **/
        // POST: api/Funkopops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funkopop>> PostFunkopop(Funkopop funkopop)
        {
            try
            {
                _context.Funkopop.Add(funkopop);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetFunkopop", new { id = funkopop.FunkoId }, funkopop);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Funkopops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFunkopop(int id)
        {
            try
            {
                var funkopop = await _context.Funkopop.Include(c => c.EstValue).FirstOrDefaultAsync(c => c.FunkoId == id);
                if (funkopop == null)
                {
                    throw new Exception("Not Found");
                }

                _context.Funkopop.Remove(funkopop);
                var estvalue = await _context.FunkoValues.FirstOrDefaultAsync(e => e.Estvalue == funkopop.EstValue.Estvalue);
                _context.FunkoValues.Remove(estvalue);
                await _context.SaveChangesAsync();

                return StatusCode(200, "Deleted");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }

        private bool FunkopopExists(int id)
        {
            return _context.Funkopop.Any(e => e.FunkoId == id);
        }
    }
}
