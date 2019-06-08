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
    public class MaterialOutController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MaterialOutController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MaterialOut
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialOut>>> GetMaterialOuts()
        {
            return await _context.MaterialOuts.Include(x=> x.StokMaterialOut).ToListAsync();
        }

        // GET: api/MaterialOut/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialOut>> GetMaterialOut(string id)
        {
            var materialOut = await _context.MaterialOuts.FindAsync(id);

            if (materialOut == null)
            {
                return NotFound();
            }

            return materialOut;
        }

        // PUT: api/MaterialOut/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutMaterialOut(MaterialOut materialOut)
        {
            var exMatOut = _context.MaterialOuts.Where(x => x.Id == materialOut.Id).Include(x=> x.StokMaterialOut).SingleOrDefault(x=>x.Id == materialOut.Id);
            if (exMatOut == null)
            {
                return NotFound("Id not found");
            }

            var newMatOut = materialOut.StokMaterialOut.Except(exMatOut.StokMaterialOut, new StokMaterialOutComparer());
            var delMatOut = exMatOut.StokMaterialOut.Except(materialOut.StokMaterialOut, new StokMaterialOutComparer());

            if (newMatOut.Any())
            {
                foreach (var item in newMatOut)
                {
                    _context.Stoks.Find(item.StokID).IsOut = true;
                }
            }

            if (delMatOut.Any())
            {
                foreach (var item in delMatOut)
                {
                    _context.Stoks.Find(item.StokID).IsOut = false;
                }
            }
            exMatOut.ModifiedDate = DateTime.Now;
            exMatOut.StokMaterialOut = materialOut.StokMaterialOut;
            
            _context.StokMaterialOut.RemoveRange(_context.StokMaterialOut.Where(x => x.Id == materialOut.Id));
            _context.StokMaterialOut.AddRange(materialOut.StokMaterialOut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialOut", new { id = materialOut.Id }, materialOut);
        }

        // POST: api/MaterialOut
        [HttpPost]
        public async Task<ActionResult<MaterialOut>> PostMaterialOut(MaterialOut materialOut)
        {
            materialOut.Id = IdGen.CreateId(IdGen.OUT_PREFIX, _context.MaterialOuts.Count());
            foreach (var item in materialOut.StokMaterialOut)
            {
                item.Id = materialOut.Id;
                _context.Stoks.Find(item.StokID).IsOut = true;
            }
            _context.MaterialOuts.Add(materialOut);
            _context.StokMaterialOut.AddRange(materialOut.StokMaterialOut);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterialOut", new { id = materialOut.Id }, materialOut);
        }

        // DELETE: api/MaterialOut/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialOut>> DeleteMaterialOut(string id)
        {
            var materialOut = await _context.MaterialOuts.FindAsync(id);
            if (materialOut == null)
            {
                return NotFound();
            }

            _context.MaterialOuts.Remove(materialOut);
            await _context.SaveChangesAsync();

            return materialOut;
        }

        private bool MaterialOutExists(string id)
        {
            return _context.MaterialOuts.Any(e => e.Id == id);
        }
    }
}
