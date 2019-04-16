using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

[assembly:ApiConventionType(typeof(DefaultApiConventions))]
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusQCController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StatusQCController(DatabaseContext context)
        {
            _context = context;
            if(_context.StatusQCs.Count() == 0)
            {
                _context.StatusQCs.Add(new StatusQC { Name = "UNAPPROVE" });
                _context.StatusQCs.Add(new StatusQC { Name = "PASS" });
                _context.StatusQCs.Add(new StatusQC { Name = "QUARANTINE" });
                _context.StatusQCs.Add(new StatusQC { Name = "BLOCK" });
                _context.SaveChanges();
            }
        }

        // GET: api/StatusQC
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusQC>>> GetStatusQCs()
        {
            return await _context.StatusQCs.ToListAsync();
        }

        // GET: api/StatusQC/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusQC>> GetStatusQC(int id)
        {
            var statusQC = await _context.StatusQCs.FindAsync(id);

            if (statusQC == null)
            {
                return NotFound();
            }

            return statusQC;
        }

        //// PUT: api/StatusQC/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStatusQC(int id, StatusQC statusQC)
        //{
        //    if (id != statusQC.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(statusQC).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StatusQCExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/StatusQC
        //[HttpPost]
        //public async Task<ActionResult<StatusQC>> PostStatusQC(StatusQC statusQC)
        //{
        //    _context.StatusQCs.Add(statusQC);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStatusQC", new { id = statusQC.Id }, statusQC);
        //}

        //// DELETE: api/StatusQC/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<StatusQC>> DeleteStatusQC(int id)
        //{
        //    var statusQC = await _context.StatusQCs.FindAsync(id);
        //    if (statusQC == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.StatusQCs.Remove(statusQC);
        //    await _context.SaveChangesAsync();

        //    return statusQC;
        //}

        private bool StatusQCExists(int id)
        {
            return _context.StatusQCs.Any(e => e.Id == id);
        }
    }
}
