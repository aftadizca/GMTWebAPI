
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.CostumModel;
using WebApi.Helper;
using WebApi.IRepository;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IGMTRepository<Stok> _stokRepo;

        public StokController(DatabaseContext context, IGMTRepository<Stok> stokRepo)
        {
            _context = context;
            _stokRepo = stokRepo;
        }

        // GET: api/Stok
        [HttpGet]
        public ActionResult<IEnumerable<Stok>> GetStoks()
        {
            return Ok(_stokRepo.GetAll());
        }

        [HttpGet("/api/graph")]
        public ActionResult Graph()
        {
            Dictionary<string, int[]> dataInc = new Dictionary<string, int[]>();
            Dictionary<string, int[]> dataOut = new Dictionary<string, int[]>();
            dataInc.Add("DUS", new int[12]);
            dataInc.Add("SEAL", new int[12]);
            dataInc.Add("CUP",new int[12]);

            dataOut.Add("DUS", new int[12]);
            dataOut.Add("SEAL", new int[12]);
            dataOut.Add("CUP",new int[12]);

            var query = _context.Stoks.Join(_context.Materials,
                    stok => stok.MaterialID,
                    material => material.Id,
                    (stok, material) => new { Type = material.Type, IsOut = stok.IsOut, Date = stok.ComingDate.Month, IsDeleted = stok.IsDeleted, qty = stok.QTY })
                    .Where(x=> x.IsDeleted == false);
            var incQ = query.Where(x => x.IsOut == false);
            var outQ = query.Where(x => x.IsOut == true);

            for (int i = 1; i<13; i++)
            { 
                dataInc["DUS"][i - 1] = incQ.Where(x=> x.Type == "DUS" && x.Date == i).Sum(x=> x.qty);
                dataInc["SEAL"][i - 1] = incQ.Where(x => x.Type == "SEAL" && x.Date == i).Sum(x => x.qty);
                dataInc["CUP"][i - 1] = incQ.Where(x => x.Type == "CUP" && x.Date == i).Sum(x => x.qty);

                dataOut["DUS"][i - 1] = outQ.Where(x=> x.Type == "DUS" && x.Date == i).Sum(x => x.qty);
                dataOut["SEAL"][i - 1] = outQ.Where(x => x.Type == "SEAL" && x.Date == i).Sum(x => x.qty);
                dataOut["CUP"][i - 1] = outQ.Where(x => x.Type == "CUP" && x.Date == i).Sum(x => x.qty);
            }

            return Ok(new { Incoming = dataInc, Outcoming = dataOut });
        }

        // GET: api/Stok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stok>> GetStok(string id)
        {
            var result = await _stokRepo.Get(id);
            if (result == null)
            {
                return NotFound("Material not found");
            }
            return Ok(result);
        }

        // PUT: api/Stok/5
        [HttpPut]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> PutStok([FromBody] List<Stok> stoks)
        {
            if (_stokRepo.IsExists(stoks))
            {
                foreach (var stok in stoks)
                {
                    _stokRepo.Put(stok);
                }

            }
            else
            {
                return NotFound("Stok not found");
            }

            try
            {
                await _stokRepo.Save();
            }
            catch (Exception)
            {
                return BadRequest("Stok not saved");
            }

            return Ok(stoks);
        }

        // POST: api/Stok
        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(typeof(List<Stok>), StatusCodes.Status201Created)]
        public async Task<ActionResult<NewStok>> PostStok(NewStok newStok)
        {
            List<Stok> stok = new List<Stok>();
            if (newStok.Qty <= newStok.Pallet)
            {
                stok.Add(new Stok { Id = IdGen.CreateId("TRC", _context.Stoks.Count() + 1), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = newStok.Qty });
                _context.Stoks.Add(stok[0]);
            }
            else if (newStok.Qty > newStok.Pallet)
            {
                int stokCount = newStok.Qty / newStok.Pallet;
                int sisa = newStok.Qty % newStok.Pallet;
                for (int i = 0; i < stokCount; i++)
                {
                    stok.Add(new Stok { Id = IdGen.CreateId("TRC", _context.Stoks.Count() + i), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = newStok.Pallet });
                }
                if (sisa != 0)
                {
                    stok.Add(new Stok { Id = IdGen.CreateId("TRC", _context.Stoks.Count() + stokCount), Lot = newStok.Lot, ExpiredDate = newStok.ExpiredDate, MaterialID = newStok.MaterialID, QTY = sisa });
                }

            }
            else
            {
                return BadRequest();
            }
            _context.Stoks.AddRange(stok);
            await _context.SaveChangesAsync();

            return StatusCode(201, stok);
        }

        // DELETE: api/Stok/5
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Stok>> DeleteStok([FromBody]List<Stok> stoks)
        {
            if (!_stokRepo.Delete(stoks))
            {
                return NotFound("Id not found!");
            }

            try
            {
                await _stokRepo.Save();
            }
            catch (System.Exception)
            {
                return BadRequest("Item not deleted");
            }

            return NoContent();
        }
    }
}
