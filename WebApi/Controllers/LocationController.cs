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
    public class LocationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LocationController(DatabaseContext context)
        {
            _context = context;
        }

        //// GET: api/Location
        //[HttpGet("/api/locationmap")]
        //public ActionResult<IEnumerable<LocationStock>> GetLocationMaps()
        //{
        //    var locstok = new List<LocationStock>();
        //    var location = _context.Locations.Select(x=>x);
        //    foreach (var loc in location)
        //    {
        //        var stok = _context.Stoks.FirstOrDefault(x => x.LocationID == loc.Id);
        //        if (stok != null)
        //        {
        //            var material = _context.Materials.FirstOrDefault(x => x.Id == stok.MaterialID);
        //            locstok.Add( new LocationStock { Id = loc.Id, Location= loc.Name, TraceID= stok.Id});
        //        }
        //        else
        //        {
        //            locstok.Add(new LocationStock { Id = loc.Id, Location = loc.Name, TraceID = "" });
        //        }

        //    }

        //    return locstok;
        //}

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(string id, Location location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = location.Id }, location);
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Location>> DeleteLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return location;
        }

        private bool LocationExists(string id)
        {
            return _context.Locations.Any(e => e.Id == id);
        }
    }
}
