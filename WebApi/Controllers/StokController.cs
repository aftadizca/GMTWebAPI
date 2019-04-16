using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Helper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StokController(DatabaseContext context)
        {
            _context = context;
            if (_context.Stoks.Count() == 0)
            {
                int i = 0;
                _context.Stoks.Add(new Stok {TraceID=IdGen.CreateId("TRC",++i), MaterialID = "30000002",LocationID=1,ComingDate=DateTime.Now,ExpiredDate=DateTime.Now.AddYears(2),Lot="1235545",StatusQCID=2,QTY=1400 });
                _context.SaveChanges();
            }
        }

        // GET: api/Stok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stok>>> GetStoks()
        {
            return await _context.Stoks.ToListAsync();
        }

        // GET: api/Stok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stok>> GetStok(string id)
        {
            var stok = await _context.Stoks.FindAsync(id);

            if (stok == null)
            {
                return NotFound();
            }

            return stok;
        }

        // PUT: api/Stok/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStok(string id, Stok stok)
        {
            if (id != stok.TraceID)
            {
                return BadRequest();
            }

            _context.Entry(stok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StokExists(id))
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

        // POST: api/Stok
        [HttpPost]
        public async Task<ActionResult<Stok>> PostStok(Stok stok)
        {
            _context.Stoks.Add(stok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStok", new { id = stok.TraceID }, stok);
        }

        // DELETE: api/Stok/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stok>> DeleteStok(string id)
        {
            var stok = await _context.Stoks.FindAsync(id);
            if (stok == null)
            {
                return NotFound();
            }

            _context.Stoks.Remove(stok);
            await _context.SaveChangesAsync();

            return stok;
        }

        private bool StokExists(string id)
        {
            return _context.Stoks.Any(e => e.TraceID == id);
        }
    }
}
